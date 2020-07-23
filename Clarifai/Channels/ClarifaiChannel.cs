using System;
using Grpc.Core;
using Grpc.Net.Client;

namespace Clarifai.Channels
{
    public static class ClarifaiChannel
    {
        public static GrpcChannel Grpc(string url = "https://api.clarifai.com:443")
        {
            return GrpcChannel.ForAddress(url);
        }

        public static Channel InsecureGrpc()
        {
            return new Channel("api-grpc.clarifai.com", 18080, ChannelCredentials.Insecure);
        }
    }
}