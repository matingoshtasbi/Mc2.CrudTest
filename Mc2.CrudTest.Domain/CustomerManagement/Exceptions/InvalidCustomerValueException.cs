using Mc2.CrudTest.Application.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Domain.CustomerManagement.Exceptions
{
    public class InvalidCustomerValueException : DomainException
    {
        public InvalidCustomerValueException(string message) : base(message)
        {
        }
        public InvalidCustomerValueException(string message, string[] parameters) : base(message, parameters)
        {
        }
        public InvalidCustomerValueException(string message, List<DomainExceptionDetail> details) : base(message, details)
        {
        }
        public InvalidCustomerValueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
