namespace TronSdk.Contracts {
    public interface IContractClientFactory {
        IContractClient CreateClient(ContractProtocol protocol);
    }
}
