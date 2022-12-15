using Mc2.CrudTest.Domain.CustomerManagement.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Infrastructure.Persistence.Configurations.CustomerManagement
{
    internal class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            //00989309756517 => 14 lenght 
            builder.ToTable("Customers");
            builder.Property(x => x.PhoneNumber)
            .HasMaxLength(14);
        }
    }
}