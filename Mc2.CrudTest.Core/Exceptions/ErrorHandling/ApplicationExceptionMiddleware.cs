using System;
using System.Globalization;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Mc2.CrudTest.Application.Core.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Mc2.CrudTest.Application.Core.Exceptions.ErrorHandling
{
    public class ApplicationExceptionMiddleware
    {
        #region members
        private readonly RequestDelegate _next;
        private readonly IExceptionHandler _exceptionHandler;
        private readonly ILogger<ApplicationExceptionMiddleware> _logger;
        #endregion

        #region constractor
        public ApplicationExceptionMiddleware(
            RequestDelegate next,
            IExceptionHandler exceptionHandler,
            ILogger<ApplicationExceptionMiddleware> logger)
        {
            _next = next;
            _exceptionHandler = exceptionHandler;
            _logger = logger;
        }
        #endregion

        #region public methods
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                var error = _exceptionHandler.HandleException(ex);
                var result = JsonSerializer.Serialize(error);

                httpContext.Response.ContentType = "application/problem+json";
                httpContext.Response.StatusCode = (int)error.StatusCode;
                await httpContext.Response.WriteAsync(result);

            }
        }
        #endregion
    }
}
