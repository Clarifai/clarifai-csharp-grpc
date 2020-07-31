using System;
using System.Collections.Generic;
using Clarifai.Api;
using Clarifai.Channels;
using Grpc.Core;
using NUnit.Framework;
using StatusCode = Clarifai.Api.Status.StatusCode;

namespace Clarifai.IntegrationTests
{
    public class IntegrationTests
    {
        private readonly string DOG_IMAGE_URL = "https://samples.clarifai.com/dog2.jpeg";
        private readonly string NON_EXISTING_IMAGE_URL = "http://example.com/non-existing.jpg";

        private readonly string GENERAL_MODEL_ID = "aaa03c23b3724a16a56b629203edc62c";

        private Metadata _metadata;
        private V2.V2Client _client;

        [SetUp]
        public void Setup()
        {
            _client = new V2.V2Client(ClarifaiChannel.Grpc(
                Environment.GetEnvironmentVariable("CLARIFAI_BASE")
            ));

            _metadata = new Metadata
            {
                {"Authorization", "Key " + Environment.GetEnvironmentVariable("CLARIFAI_KEY")}
            };
        }

        [Test]
        public void GetModel()
        {
            var response = _client.GetModel(
                new GetModelRequest() { ModelId = GENERAL_MODEL_ID },
                _metadata
            );
            if (response.Status.Code != StatusCode.Success) Assert.Fail(response.ToString());

            Assert.AreEqual("general", response.Model.Name);
        }

        [Test]
        public void ListModelsWithPagination()
        {
            var response1 = _client.ListModels(
                new ListModelsRequest() { PerPage = 2 },
                _metadata
            );
            if (response1.Status.Code != StatusCode.Success) Assert.Fail(response1.ToString());

            Assert.AreEqual(2, response1.Models.Count);

            // We shouldn't have 1000*500 number of models, so the result should be empty.
            var response2 = _client.ListModels(
                new ListModelsRequest() { Page = 1000, PerPage = 500 },
                _metadata
            );
            if (response2.Status.Code != StatusCode.Success) Assert.Fail(response2.ToString());
        }

        [Test]
        public void PostModelOutputs()
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
            if (response.Status.Code != StatusCode.Success) Assert.Fail(response.ToString());

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
            Assert.AreEqual(StatusCode.Failure, response.Status.Code);
            Assert.AreEqual("Failure", response.Status.Description);
            Assert.AreEqual(StatusCode.InputDownloadFailed, response.Outputs[0].Status.Code);
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
    }
}
