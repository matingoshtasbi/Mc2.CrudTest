using Mc2.CrudTest.Application.Contract.DTOs.CustomerManagement;
using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Contract.Queries.CustomerManagement
{
    public class GetCustomersQuery : IRequest<CustomerVM>
    {
        public Guid Id { get; }

        public GetCustomersQuery(Guid id)
        {
            Id = id;
        }

    }
}
