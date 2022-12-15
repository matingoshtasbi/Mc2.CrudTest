using Mc2.CrudTest.Application.Contract.ViewModels.CustomerManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.ReadModules.Configurations.CustomerManagement
{
    internal class CustomerVMEntityConfiguration : IEntityTypeConfiguration<CustomerVM>
    {
        public void Configure(EntityTypeBuilder<CustomerVM> builder)
        {
        }
    }
}