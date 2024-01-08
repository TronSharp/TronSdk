namespace TronSdk {
    using Contracts;

    public interface ITronClient {
        TronNetwork TronNetwork { get; }

        IGrpcChannelClient GetChannel();

        IWalletClient GetWallet();

        ITransactionClient GetTransaction();

        IContractClient GetContract();
    }
}
