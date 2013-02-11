using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SortingAlgorithms
{
    /// <summary>
    /// Custom Exception Handling class
    /// </summary>
    class SortingException : Exception
    {
        public SortingException() : base() { }
        public SortingException(string message) : base(message) { }
        public SortingException(string message, Exception innerException) : base(message, innerException) { }
        public SortingException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
