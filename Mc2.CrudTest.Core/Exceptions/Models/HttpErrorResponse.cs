using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Core.Exceptions.Models
{
    public class HttpErrorResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; } = default!;
        public string Exception { get; set; } = default!;
        public List<ErrorDetail> Details { get; set; } = new List<ErrorDetail>();
    }
}
