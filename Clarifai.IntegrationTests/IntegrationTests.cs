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
        public void ListConcepts()
        {
            var response = _client.ListConcepts(new ListConceptsRequest(), _metadata);
            if (response.Status.Code != StatusCode.Success) Assert.Fail(response.ToString());

            Assert.NotZero(response.Concepts.Count);
        }

        [Test]
        public void GetModel()
        {
            var response = _client.GetModel(
                new GetModelRequest() { ModelId = "aaa03c23b3724a16a56b629203edc62c" },
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
                    ModelId = "aaa03c23b3724a16a56b629203edc62c",
                    Inputs = { new List<Input>() {
                            new Input()
                            {
                                Data = new Data()
                                {
                                    Image = new Image()
                                    {
                                        Url = "https://samples.clarifai.com/dog2.jpeg"
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
    }
}