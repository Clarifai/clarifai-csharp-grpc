![Clarifai logo](docs/logo.png)

# Clarifai C# gRPC Client

This is the official Clarifai gRPC C# client for interacting with our powerful recognition
[API](https://docs.clarifai.com).
Clarifai provides a platform for data scientists, developers, researchers and enterprises to master the entire
artificial intelligence lifecycle. Gather valuable business insights from images, video and text using computer vision
and natural language processing.

* Try the Clarifai demo at: https://clarifai.com/demo
* Sign up for a free account at: https://portal.clarifai.com/signup
* Read the documentation at: https://docs.clarifai.com/

[![NuGet](https://img.shields.io/nuget/v/ClarifaiGrpc.svg)](https://www.nuget.org/packages/ClarifaiGrpc)
[![Run tests](https://github.com/Clarifai/clarifai-csharp-grpc/workflows/Run%20tests/badge.svg)](https://github.com/Clarifai/clarifai-csharp-grpc/actions)

## Installation

Install it via the NuGet Package Manager by searching for `ClarifaiGrpc`, or use one of the commands below.

```
Install-Package ClarifaiGrpc
dotnet add package ClarifaiGrpc
```

## Getting started

Construct the client and setup your API key or Personal Access Token in the `metadata` variable.

```csharp
var client = new V2.V2Client(ClarifaiChannel.Grpc());

var metadata = new Metadata
{
    {"Authorization", "Key {MY_CLARIFAI_API_KEY_OR_PAT}"}
};
```

Predict concepts in an image:

```csharp
var response = client.PostModelOutputs(
    new PostModelOutputsRequest()
    {
        ModelId = "aaa03c23b3724a16a56b629203edc62c",
        Inputs =
        {
            new List<Input>()
            {
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
            }
        }
    },
    metadata
);
if (response.Status.Code != StatusCode.Success)
    throw new Exception("Request failed, response: " + response);

Console.WriteLine("Predicted concepts:");
foreach (var concept in response.Outputs[0].Data.Concepts)
{
    Console.WriteLine($"{concept.Name, 15} {concept.Value:0.00}");
}
```
