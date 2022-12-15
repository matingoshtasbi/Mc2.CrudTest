using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exceptions
{
    public class DomainException : Exception
    {
        #region properties
        string _message;
        public virtual string Message { get { return _message; } }
        public List<DomainExceptionDetail> Details { get; set; } = new List<DomainExceptionDetail>();
        #endregion

        #region constractor
        public DomainException()
        {
        }
        public DomainException(string message) : base(message)
        {
        }
        public DomainException(string message, string[] parameters)
        {
            _message = string.Format(message, parameters);
        }
        public DomainException(string message, List<DomainExceptionDetail> details) : base(message)
        {
            this.Details = details;
        }
        public DomainException(string message, Exception innerException) : base(message, innerException)
        { 
        }
        #endregion
    }
}
