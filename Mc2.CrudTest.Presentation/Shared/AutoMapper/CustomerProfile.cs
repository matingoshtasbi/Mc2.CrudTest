using AutoMapper;
using Mc2.CrudTest.Application.Contract.DTOs.CustomerManagement;
using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Mc2.CrudTest.Domain.CustomerManagement.ParameterObjects;

namespace Mc2.CrudTest.Shared.AutoMapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerVM>();
            CreateMap<CustomerVM, CustomerRequest>();
            CreateMap<CustomerRequest, CustomerPO>();
        }
    }
}
