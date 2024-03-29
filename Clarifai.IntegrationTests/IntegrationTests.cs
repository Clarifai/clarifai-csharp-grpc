using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using Clarifai.Api;
using Clarifai.Channels;
using Google.Protobuf;
using Grpc.Core;
using NUnit.Framework;
using StatusCode = Clarifai.Api.Status.StatusCode;
using Task = System.Threading.Tasks.Task;

namespace Clarifai.IntegrationTests
{
    public class IntegrationTests
    {
        private readonly string DOG_IMAGE_URL = "https://samples.clarifai.com/dog2.jpeg";
        private readonly string TRUCK_IMAGE_URL = "https://samples.clarifai.com/red-truck.png";
        private readonly string NON_EXISTING_IMAGE_URL = "http://example.com/non-existing.jpg";

        private readonly string GENERAL_MODEL_ID = "aaa03c23b3724a16a56b629203edc62c";

        private Metadata _metadata;
        private V2.V2Client _client;

        [SetUp]
        public void Setup()
        {
            _client = new V2.V2Client(ClarifaiChannel.Grpc(
                Environment.GetEnvironmentVariable("CLARIFAI_GRPC_BASE")
            ));

            _metadata = new Metadata
            {
                {"Authorization", "Key " + Environment.GetEnvironmentVariable("CLARIFAI_API_KEY")}
            };
        }

        [Test]
        public void GetModel()
        {
            var response = _client.GetModel(
                new GetModelRequest() { ModelId = GENERAL_MODEL_ID },
                _metadata
            );
            RaiseOnFailure(response);

            Assert.AreEqual("Image Recognition", response.Model.Name);
        }

        [Test]
        public void ListModelsWithPagination()
        {
            var response1 = _client.ListModels(
                new ListModelsRequest() { PerPage = 2 },
                _metadata
            );
            RaiseOnFailure(response1);

            Assert.AreEqual(2, response1.Models.Count);

            // We shouldn't have 1000*500 number of models, so the result should be empty.
            var response2 = _client.ListModels(
                new ListModelsRequest() { Page = 1000, PerPage = 500 },
                _metadata
            );
            RaiseOnFailure(response2);
        }

        [Test]
        public void PostModelOutputsWithUrl()
        {
            var response = _client.PostModelOutputs(
                new PostModelOutputsRequest()
                {
                    ModelId = GENERAL_MODEL_ID,
                    Inputs = { new List<Input>() {
                            new Input()
                            {
                                Data = new Data()
                                {
                                    Image = new Image()
                                    {
                                        Url = DOG_IMAGE_URL
                                    }
                                }
                            }
                    } }
                },
                _metadata
            );
            RaiseOnFailure(response);

            Assert.AreNotEqual(0, response.Outputs[0].Data.Concepts.Count);
        }

        [Test]
        public void PostModelOutputsWithFileBytes()
        {
            ByteString bytes;

            using (FileStream stream = File.OpenRead("assets/red-truck.png"))
            {
                bytes = ByteString.FromStream(stream);
            }

            var response = _client.PostModelOutputs(
                new PostModelOutputsRequest()
                {
                    ModelId = GENERAL_MODEL_ID,
                    Inputs = { new List<Input>() {
                            new Input()
                            {
                                Data = new Data()
                                {
                                    Image = new Image()
                                    {
                                        Base64 = bytes
                                    }
                                }
                            }
                    } }
                },
                _metadata
            );
            RaiseOnFailure(response);

            Assert.AreNotEqual(0, response.Outputs[0].Data.Concepts.Count);
        }

        [Test]
        public void FailedPostModelOutputs()
        {
            var response = _client.PostModelOutputs(
                new PostModelOutputsRequest()
                {
                    ModelId = GENERAL_MODEL_ID,
                    Inputs = { new List<Input> {
                            new Input
                            {
                                Data = new Data
                                {
                                    Image = new Image
                                    {
                                        Url = NON_EXISTING_IMAGE_URL
                                    }
                                }
                            }
                    } }
                },
                _metadata
            );
            Assert.AreEqual(StatusCode.InputDownloadFailed, response.Status.Code);
        }

        [Test]
        public void MixedSuccessPostModelOutputs()
        {
            var response = _client.PostModelOutputs(
                new PostModelOutputsRequest
                {
                    ModelId = GENERAL_MODEL_ID,
                    Inputs = { new List<Input> {
                            new Input
                            {
                                Data = new Data
                                {
                                    Image = new Image
                                    {
                                        Url = DOG_IMAGE_URL
                                    }
                                }
                            },
                            new Input
                            {
                                Data = new Data
                                {
                                    Image = new Image
                                    {
                                        Url = NON_EXISTING_IMAGE_URL
                                    }
                                }
                            },
                    } }
                },
                _metadata
            );
            Assert.AreEqual(StatusCode.MixedStatus, response.Status.Code);
            Assert.AreEqual(StatusCode.Success, response.Outputs[0].Status.Code);
            Assert.AreEqual(StatusCode.InputDownloadFailed, response.Outputs[1].Status.Code);
        }

        [Test]
        [Ignore("temporarily fails")]
        public void PostPatchAndDeleteInput()
        {
            MultiInputResponse postInputsResponse = _client.PostInputs(
                new PostInputsRequest
                {
                    Inputs =
                    {
                        new List<Input>
                        {
                            new Input
                            {
                                Data = new Data
                                {
                                    Image = new Image
                                    {
                                        Url = TRUCK_IMAGE_URL,
                                        AllowDuplicateUrl = true
                                    },
                                    Concepts =
                                    {
                                        new List<Concept>
                                        {
                                            new Concept
                                            {
                                                Id = "red-truck"
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                },
                _metadata
            );
            RaiseOnFailure(postInputsResponse);

            string inputId = postInputsResponse.Inputs[0].Id;
            try
            {
                while (true)
                {
                    var getInputResponse = _client.GetInput(
                        new GetInputRequest {InputId = inputId},
                        _metadata
                    );
                    RaiseOnFailure(getInputResponse);
                    var inputStatusCode = getInputResponse.Input.Status.Code;
                    if (inputStatusCode == StatusCode.InputDownloadSuccess)
                        break;
                    if (inputStatusCode != StatusCode.InputDownloadPending &&
                        inputStatusCode != StatusCode.InputDownloadInProgress)
                        throw new Exception(
                            $"Waiting for input ID {inputId} failed, status code is " +
                            $"{inputStatusCode}");
                    Thread.Sleep(1_000);
                }

                var patchInputsResponse = _client.PatchInputs(
                    new PatchInputsRequest
                    {
                        Action = "overwrite",
                        Inputs = { new List<Input>
                        {
                            new Input
                            {
                                Id = inputId,
                                Data = new Data
                                {
                                    Concepts = { new List<Concept>
                                    {
                                        new Concept
                                        {
                                            Id = "very-red-truck"
                                        }
                                    }}
                                }
                            }
                        }}
                    },
                    _metadata
                );
                RaiseOnFailure(patchInputsResponse);
            }
            finally
            {
                var deleteInputsResponse = _client.DeleteInput(
                    new DeleteInputRequest
                    {
                        InputId = inputId
                    },
                    _metadata
                );
                RaiseOnFailure(deleteInputsResponse);
            }
        }

        private void RaiseOnFailure(dynamic response)
        {
            dynamic status = response.Status;
            if (status.Code != StatusCode.Success)
            {
                throw new Exception(
                    $"Unexpected failure response: {status.Code} {status.Description} " +
                    $"{status.Details}. Whole response object: {response}");
            }
        }
    }
}
