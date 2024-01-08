using System.Numerics;
using TronSdk.ABI.FunctionEncoding.Attributes;

namespace TronSdk.Contracts {
    [Function("transferFrom", "bool")]
    public class TransferFromFunction : FunctionMessage
    {
        [Parameter("address", "_from", 1)]
        public string From { get; set; }

        [Parameter("address", "_to", 1)]
        public string To { get; set; }

        [Parameter("uint256", "_value", 2)]
        public BigInteger TokenAmount { get; set; }
    }
}
