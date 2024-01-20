using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array_GenericTypes.Exceptions;
[Serializable]
public class GenericException : Exception
{
    public GenericException() { }
    public GenericException(string message) : base("Exception occurred -> " + message) { }
    public GenericException(string message, Exception inner) : base(message, inner) { }
    protected GenericException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
}