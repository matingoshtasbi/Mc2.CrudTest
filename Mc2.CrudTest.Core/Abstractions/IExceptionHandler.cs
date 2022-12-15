using Mc2.CrudTest.Application.Core.Exceptions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Abstractions
{
    public interface IExceptionHandler
    {
        public HttpErrorResponse HandleException(Exception exception);
    }
}
