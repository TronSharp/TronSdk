using TronSdk.ABI.FunctionEncoding.Attributes;

namespace TronSdk.ABI.FunctionEncoding {
    [Function("Error")]
    public class ErrorFunction {
        public const string ERROR_FUNCTION_ID = "0x08c379a0";

        [Parameter("string")]
        public string Message { get; set; }

        public static bool IsErrorData(string dataHex) {
            return dataHex.StartsWith(ERROR_FUNCTION_ID);
        }
    }
}