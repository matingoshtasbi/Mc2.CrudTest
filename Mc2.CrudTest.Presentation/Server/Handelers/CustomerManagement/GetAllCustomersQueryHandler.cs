using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;
using Mc2.CrudTest.Application.Contract.Queries.CustomerManagement;
using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using Mc2.CrudTest.Application.Core.DTOs;
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
    internal class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, PageResult<CustomerVM>>
    {
        #region member
        private readonly ICustomerManagementQueryService _queryService;
        #endregion

        #region constractor
        public GetAllCustomersQueryHandler(ICustomerManagementQueryService queryService)
        {
            _queryService = queryService;
        }
        #endregion
        public async Task<PageResult<CustomerVM>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _queryService.FindEmployees(request.FindCustomerRequest);
        }
    }
}
