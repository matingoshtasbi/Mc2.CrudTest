using Mc2.CrudTest.Application.Contract.DTOs.CustomerManagement;
using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using Mc2.CrudTest.Application.Core.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Contract.Queries.CustomerManagement
{
    public class GetAllCustomersQuery : IRequest<PageResult<CustomerVM>>
    {
        public FindCustomerRequest FindCustomerRequest { get; set; }

        public GetAllCustomersQuery(FindCustomerRequest findCustomerRequest)
        {
            FindCustomerRequest = findCustomerRequest;
        }
    }
}
