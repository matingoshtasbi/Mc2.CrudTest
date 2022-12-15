using AutoMapper;
using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;
using Mc2.CrudTest.Application.Contract.DTOs.CustomerManagement;
using Mc2.CrudTest.Application.Core.Exceptions;
using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Mc2.CrudTest.Domain.CustomerManagement.Localization;
using Mc2.CrudTest.Domain.CustomerManagement.ParameterObjects;
using Mc2.CrudTest.Domain.CustomerManagement.Services;
using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Services.CustomerManagement
{
    public class CustomerManagementCommandService : ICustomerManagementCommandService
    {
        #region members
        private readonly IMapper _mapper;
        private readonly IServiceProvider _provider;
        private readonly ICustomerRepository _customerRepository;
        #endregion

        #region constractors
        public CustomerManagementCommandService(IMapper mapper,
            IServiceProvider provider,
            ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _provider = provider;
            _customerRepository = customerRepository;
        }
        #endregion

        #region private methods


        #endregion


        #region public methods
        public async Task<Guid> AddCustomer(CustomerRequest request)
        {
            var customerPO = _mapper.Map<CustomerPO>(request);
            var customerService = (ICustomerService)_provider.GetService(typeof(ICustomerService));
            var customer = CustomerFactory.Create(customerPO, customerService);

            _customerRepository.Add(customer);
            await _customerRepository.UnitOfWork.SaveChangesAsync();

            return customer.Id;
        }
        public async Task UpdateCustomer(CustomerRequest request)
        {
            if (Guid.Empty == request.Id)
                throw new ApplicationLayerException(CustomerManagementLocalization.FieldCannotBeEmpty, new string[] { CustomerManagementLocalization.CustomerId });

            var customerPO = _mapper.Map<CustomerPO>(request);

            var customer = _customerRepository.Get(request.Id);
            
            if(customer == null)
                throw new ApplicationLayerException(CustomerManagementLocalization.ResourseNotFound, new string[] { CustomerManagementLocalization.Customer });

            customer.CustomerService = (ICustomerService)_provider.GetService(typeof(ICustomerService));
            customer.UpdateProperties(customerPO);

            await _customerRepository.UnitOfWork.SaveChangesAsync();
        }
        public async Task RemoveCustomer(Guid customerId)
        {
            var customer = _customerRepository.Get(customerId);

            if (customer == null)
                throw new ApplicationLayerException(CustomerManagementLocalization.ResourseNotFound, new string[] { CustomerManagementLocalization.Customer });

            _customerRepository.Remove(customerId);
            await _customerRepository.UnitOfWork.SaveChangesAsync();
        }
        #endregion
    }
}
