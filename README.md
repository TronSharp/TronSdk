# TronSdk

The dotnet C# SDK to manipulate your tron wallet for usdt/trx on trc20 chain. 

# Get Started

You will need at least .net 6.0 to use this package

## Installation via Nuget

You can install it via the nuget management GUI by searching for TronSdk or through command line.

```
Install-Package TronSdk
```

## Create TronGrid API key

If you don't have a TronGrid account yet, please register one here https://www.trongrid.io

Once registered, you can create a key here https://www.trongrid.io/dashboard/keys

## Configuration for IOC

Create a file TronServiceExtension.cs with the content below

```
public record TronRecord(IServiceProvider ServiceProvider,
  ITronClient? TronClient, IOptions<TronNetOptions>? Options);

public static class TronServiceExtension
{
  public static IServiceCollection AddTronService(this IServiceCollection services) {
    services.AddTronNet(x => {
      x.Network = TronNetwork.MainNet;
      x.Channel = new GrpcChannelOption { Host = "grpc.trongrid.io", Port = 50051 };
      x.SolidityChannel = new GrpcChannelOption { Host = "grpc.trongrid.io", Port = 50052 };
      x.ApiKey = "Your TronGrid API key";
    });
    return services;
  }

  public static TronRecord GetTronRecord(this IServiceProvider provider) {
    var client = provider.GetService<ITronClient>();
    var options = provider.GetService<IOptions<TronNetOptions>>();

    return new TronRecord(provider, client, options);
  }
}
```

In program.cs register the Tron services

```
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTronServices();
```

## Transfer usdt

```
public class MyController {
  private readonly IServiceProvider _serviceProvider;
  public MyController(IServiceProvider serviceProvider){
    _serviceProvider = serviceProvider;
  }

  /// <summary>
  /// Transfer usdt to an address
  /// </summary>
  /// <param name="privateKey">private key of your wallet</param>
  /// <param name="toAddress">address to transfer to</param>
  /// <param name="amount">the amount of usdt to transfer</param>
  /// <param name="memo">usually don't have to set</param>
  /// <returns>null if failed, and the error will be logged</returns>
  private async Task<string> UsdtTransferAsync(string privateKey,
    string toAddress, decimal amount, string? memo = null) {
    const string contractAddress = "TR7NHqjeKQxGTCi8q8ZY4pL8otSzgjLj6t";

    var record = _serviceProvider.GetTronRecord();
    var contractClientFactory = record.ServiceProvider.GetService<IContractClientFactory>();
    var contractClient = contractClientFactory?.CreateClient(ContractProtocol.TRC20)!;

    var account = new TronAccount(privateKey, TronNetwork.MainNet);

    const long feeAmount = 65L * 1000000L; // should be enough for gas fee

    return await contractClient.TransferAsync(contractAddress, account, toAddress, amount,
      memo?? "", feeAmount);
  }

  /// <summary>
  /// Transfer trx to an address
  /// </summary>
  /// <param name="privateKey">private key of your wallet</param>
  /// <param name="to">address to transfer to</param>
  /// <param name="amount">the amount of trx to transfer</param>
  private static async Task<dynamic> TrxTransferAsync(string privateKey, string to, long amount) {
    var record = _serviceProvider.GetTronRecord();
    var transactionClient = record.TronClient?.GetTransaction();

    var account = new TronAccount(privateKey, TronNetwork.MainNet);

    var transactionExtension = await transactionClient?
      .CreateTransactionAsync(account.Address, to, amount)!;

    var transactionId = transactionExtension.Txid.ToStringUtf8();

    var transactionSigned = transactionClient
      .GetTransactionSign(transactionExtension.Transaction, privateKey);
    var returnObj = await transactionClient.BroadcastTransactionAsync(transactionSigned);

    return new { Result = returnObj.Result, Message = returnObj.Message,
       TransactionId = transactionId };
  }
}
 ```
