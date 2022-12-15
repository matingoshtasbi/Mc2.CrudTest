using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;
using Mc2.CrudTest.Application.Contract.Queries.CustomerManagement;
using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using Mc2.CrudTest.Application.Services.CustomerManagement;
using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Handelers.CustomerManagement
{
    internal class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        #region member
        private readonly ICustomerManagementCommandService _commandService;
        #endregion

        #region constractor
        public UpdateCustomerCommandHandler(ICustomerManagementCommandService commandService)
        {
            _commandService = commandService;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _commandService.UpdateCustomer(request.CustomerRequest);
            return Unit.Value;
        }
        #endregion



    }
}
