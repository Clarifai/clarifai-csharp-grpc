using Grpc.Core;

namespace Clarifai.Channels
{
    public static class ClarifaiChannel
    {
        public static Channel Grpc(string url = "api.clarifai.com")
        {
            return new Channel(url, 443, new SslCredentials());
        }

        public static Channel InsecureGrpc()
        {
            return new Channel("api-grpc.clarifai.com", 18080, ChannelCredentials.Insecure);
        }
    }
}