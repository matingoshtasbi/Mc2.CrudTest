using Mc2.CrudTest.Application.Core.Domain;
using System;

namespace Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement
{
    public class CustomerVM : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ulong BankAccountNumber { get; set; }
    }
}
