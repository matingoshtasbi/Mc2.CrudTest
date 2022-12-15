using System;

namespace Mc2.CrudTest.Domain.CustomerManagement.ParameterObjects
{
    public class CustomerPO
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime DateOfBirth { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string Email { get; set; } = default!;
        public ulong BankAccountNumber { get; set; } = default!;
    }
}
