using AutoMapper;
using Mc2.CrudTest.Application.Contract.Abstractions.CustomerManagement;
using Mc2.CrudTest.Domain.CustomerManagement.Localization;
using Microsoft.Extensions.Localization;
using System;

namespace Mc2.CrudTest.Application.Services.CustomerManagement
{
    public class CustomerManagementCommandService : ICustomerManagementCommandService
    {
        #region members
        private readonly IMapper _mapper;
        private readonly IServiceProvider _provider;
        private readonly IStringLocalizer<CustomerManagementLocalization> _localizer;
        #endregion

        #region constractors
        public CustomerManagementCommandService(IMapper mapper,
            IServiceProvider provider,
            IStringLocalizer<CustomerManagementLocalization> localizer)
        {
            _mapper = mapper;
            _provider = provider;
            _localizer = localizer;
        }
        #endregion

        #region private methods

       
        #endregion


        #region public methods

        #endregion
    }
}
