using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exceptions
{
    public class ApplicationLayerException : Exception
    {
        #region properties
        string _message;
        public virtual string Message { get { return _message; } }
        #endregion

        #region constractor
        public ApplicationLayerException()
        {
        }
        public ApplicationLayerException(string message) : base(message)
        {
        }
        public ApplicationLayerException(string message,string[] parameters)
        {
            _message = string.Format(message, parameters);
        }
        public ApplicationLayerException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public ApplicationLayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        #endregion
    }
}
