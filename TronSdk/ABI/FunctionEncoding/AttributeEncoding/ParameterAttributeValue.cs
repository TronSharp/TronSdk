using System.Reflection;
using TronSdk.ABI.FunctionEncoding.Attributes;

namespace TronSdk.ABI.FunctionEncoding.AttributeEncoding {
    public class ParameterAttributeValue {
        public ParameterAttribute ParameterAttribute { get; set; }
        public object Value { get; set; }
        public PropertyInfo PropertyInfo { get; set; }
    }
}