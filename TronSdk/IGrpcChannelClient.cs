namespace TronSdk {
    using Grpc.Core;

    public interface IGrpcChannelClient {

        Channel GetProtocol();

        Channel GetSolidityProtocol();
    }
}
