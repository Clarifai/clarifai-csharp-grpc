![image](https://github.com/user-attachments/assets/c6087cf2-e4d4-4064-a111-1fa5887f4466)


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
dotnet add package ClarifaiGrpc

Install-Package ClarifaiGrpc
```

## Versioning

This library doesn't use semantic versioning. The first two version numbers (`X.Y` out of `X.Y.Z`) follow the API (backend) versioning, and
whenever the API gets updated, this library follows it.

The third version number (`Z` out of `X.Y.Z`) is used by this library for any independent releases of library-specific improvements and bug fixes.

## Getting started

Construct the client and setup your API key or Personal Access Token in the `metadata` variable.

```csharp
using System;
using System.Collections.Generic;
using Clarifai.Api;
using Clarifai.Channels;
using Grpc.Core;
using StatusCode = Clarifai.Api.Status.StatusCode;

var client = new V2.V2Client(ClarifaiChannel.Grpc());

var metadata = new Metadata
{
    {"Authorization", "Key {YOUR_PERSONAL_TOKEN}"}
};
```

Predict concepts in an image:

```csharp
var response = client.PostModelOutputs(
    new PostModelOutputsRequest()
    {
        UserAppId = 
            new UserAppIDSet()
            { 
                UserId = "{YOUR_USER_ID}",
                AppId = "{YOUR_APP_ID}"
            },
        ModelId = "aaa03c23b3724a16a56b629203edc62c", // <- This is the general model_id
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
