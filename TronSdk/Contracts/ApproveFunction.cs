using System.Numerics;
using TronSdk.ABI.FunctionEncoding.Attributes;

namespace TronSdk.Contracts {
    [Function("approve", "bool")]
    public class ApproveFunction : FunctionMessage
    {
        [Parameter("address", "_spender", 1)]
        public string Spender { get; set; }

        [Parameter("uint256", "_value", 2)]
        public BigInteger TokenAmount { get; set; }
    }
}
