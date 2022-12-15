using Mc2.CrudTest.Application.Core.Abstractions;
using Mc2.CrudTest.Application.Core.Exceptions;
using Mc2.CrudTest.Application.Core.Exceptions.Models;
using Mc2.CrudTest.Domain.CustomerManagement.Localization;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Mc2.CrudTest.Shared.ErrorHandling
{
    public class ExceptionHandler : IExceptionHandler
    {
        #region members
        private readonly ILogger<ExceptionHandler> _logger;
        private readonly IHostEnvironment _environment;
        private readonly IStringLocalizer<CustomerManagementLocalization> _localizer;
        #endregion

        #region constractor
        public ExceptionHandler(ILogger<ExceptionHandler> logger,
            IHostEnvironment environment,
            IStringLocalizer<CustomerManagementLocalization> localizer)
        {
            _logger = logger;
            _environment = environment;
            _localizer = localizer;
        }
        #endregion

        #region public methods
        public HttpErrorResponse HandleException(Exception exception)
        {
            var error = exception switch
            {
                ApplicationLayerException applicationException => HandleApplicationException(applicationException),
                DomainException domainException => HandleDomainException(domainException),
                ResourceNotFoundException resourceNotFoundException => HandleResourceNotFoundException(resourceNotFoundException),
                _ => HandleUnhandledExceptions(exception)
            };

            if (_environment.IsDevelopment())
            {
                error.Exception = exception.ToString();
            }

            return error;
        }
        #endregion

        #region public methods
        private HttpErrorResponse HandleResourceNotFoundException(ResourceNotFoundException resourceNotFoundException)
        {
            _logger.LogInformation(resourceNotFoundException, resourceNotFoundException.Message);

            return new HttpErrorResponse
            {
                Message = resourceNotFoundException.Message,
                StatusCode = HttpStatusCode.NotFound,
            };
        }

        private HttpErrorResponse HandleDomainException(DomainException domainException)
        {
            _logger.LogInformation(domainException, domainException.Message);

            var error = new HttpErrorResponse();
            error.StatusCode = HttpStatusCode.BadRequest;
            error.Message = domainException.Message;

            domainException.Details.ForEach(c =>
            {
                error.Details.Add(new ErrorDetail
                {
                    Message = c.Message,
                    Source= c.Source
                });
            });

            return error;
        }

        private HttpErrorResponse HandleApplicationException(Application.Core.Exceptions.ApplicationLayerException applicationException)
        {
            _logger.LogInformation(applicationException, applicationException.Message);

            return new HttpErrorResponse
            {
                Message = applicationException.Message,
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        private HttpErrorResponse HandleUnhandledExceptions(Exception exception)
        {
            _logger.LogError(exception, exception.Message);

            return new HttpErrorResponse
            {
                Message = "An unhandled error occurred while processing this request",
                StatusCode = HttpStatusCode.InternalServerError
            };
        }
        #endregion
    }
}
