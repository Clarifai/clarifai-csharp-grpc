using Grpc.Core;

namespace Clarifai.Channels
{
    public static class ClarifaiChannel
    {
        public static Channel Grpc(string url = "api.clarifai.com")
        {
            var maxReceiveMessageSizeOption = new ChannelOption(ChannelOptions.MaxReceiveMessageLength, 128 * 1024 * 1024); // 128 MB
            return new Channel(url, 443, new SslCredentials(), new [] { maxReceiveMessageSizeOption });
        }

        public static Channel InsecureGrpc()
        {
            var maxReceiveMessageSizeOption = new ChannelOption(ChannelOptions.MaxReceiveMessageLength, 128 * 1024 * 1024); // 128 MB
            return new Channel("api-grpc.clarifai.com", 18080, ChannelCredentials.Insecure, new [] { maxReceiveMessageSizeOption });
        }
    }
}