using TronSdk.ABI.Model;

namespace TronSdk.ABI.FunctionEncoding {
    public class ParameterOutput {
        public Parameter Parameter { get; set; }
        public int DataIndexStart { get; set; }
        public object Result { get; set; }

    }
}