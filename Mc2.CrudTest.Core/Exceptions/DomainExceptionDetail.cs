using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exceptions
{
    public class DomainExceptionDetail
    {
        #region constructors
        public DomainExceptionDetail(string message)
        {
            this.Message = message;
        }
        public DomainExceptionDetail(string message, string[] parameters)
        {
            this.Message = string.Format(message, parameters);
        }
        public DomainExceptionDetail(string message, string source)
        {
            this.Message = message;
            this.Source = source;
        }
        #endregion

        #region properties
        public string Message { get; set; }
        public string Source { get; set; }
        #endregion
    }
}

