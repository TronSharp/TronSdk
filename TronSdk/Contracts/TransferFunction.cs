﻿using System.Numerics;
using TronSdk.ABI.FunctionEncoding.Attributes;

namespace TronSdk.Contracts {
    [Function("transfer", "bool")]
    public class TransferFunction : FunctionMessage {
        [Parameter("address", "_to", 1)]
        public string To { get; set; }

        [Parameter("uint256", "_value", 2)]
        public BigInteger TokenAmount { get; set; }
    }
}
