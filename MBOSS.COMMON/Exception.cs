using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Mboss.Common
{
    [Serializable]
    public class Exception : System.Exception, ISerializable
    {
        public Exception() : base() { }
        public Exception(string errorMessage) : base(errorMessage) { }
        public Exception(string errorMessage, params object[] args) : base(string.Format(errorMessage, args)) { }
        public Exception(string errorMessage, System.Exception ex) : base(errorMessage, ex) { }
        protected Exception(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class ApplicationException : Exception
    {
        public ApplicationException() : base() { }
        public ApplicationException(string errorMessage) : base(errorMessage) { }
        public ApplicationException(string errorMessage, System.Exception ex) : base(errorMessage, ex) { }
        public ApplicationException(string errorMessage, params object[] args) : base(string.Format(errorMessage, args)) { }
        protected ApplicationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    public class DataException : Exception
    {
        public DataException() : base() { }
        public DataException(string errorMessage) : base(errorMessage) { }
        public DataException(string errorMessage, System.Exception ex) : base(errorMessage, ex) { }
        public DataException(string errorMessage, params object[] args) : base(string.Format(errorMessage, args)) { }
        protected DataException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class ArgumentException : System.ArgumentException
    {
        public ArgumentException() : base() { }
        public ArgumentException(string message) : base(message) { }
        public ArgumentException(string errorMessage, System.Exception ex) : base(errorMessage, ex) { }
        public ArgumentException(string message, string parameterName) : base(message, parameterName) { }
        protected ArgumentException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}
