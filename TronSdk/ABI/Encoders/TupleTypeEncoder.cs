using System;
using TronSdk.ABI.FunctionEncoding;
using TronSdk.ABI.Model;

namespace TronSdk.ABI.Encoders {
    public class TupleTypeEncoder : ITypeEncoder
    {
        private readonly ParametersEncoder parametersEncoder;

        public TupleTypeEncoder()
        {
            parametersEncoder = new ParametersEncoder();
        }

        public Parameter[] Components { get; set; }

        public byte[] Encode(object value)
        {
            if (!(value == null || value is object[]))
                return parametersEncoder.EncodeParametersFromTypeAttributes(value.GetType(), value);

            var input = value as object[];
            return parametersEncoder.EncodeParameters(Components, input);
        }

        public byte[] EncodePacked(object value)
        {
            throw new NotImplementedException();
        }
    }
}