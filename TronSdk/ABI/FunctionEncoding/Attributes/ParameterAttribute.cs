using System;
using TronSdk.ABI.Model;

namespace TronSdk.ABI.FunctionEncoding.Attributes {
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterAttribute : Attribute {
        public ParameterAttribute(string type, string name = null, int order = 1) {
            Parameter = new Parameter(type, name, order);
        }

        public ParameterAttribute(string type, string name, int order, bool indexed = false) : this(type, name, order) {
            Parameter.Indexed = indexed;
        }

        public ParameterAttribute(string type, int order) : this(type, null, order) {
        }

        public Parameter Parameter { get; }

        public int Order => Parameter.Order;
        public string Name => Parameter.Name;
        public string Type => Parameter.Type;
    }
}