using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Domain;

namespace TestApp.Data.Configurations
{
    public class UserDomainConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Username).IsRequired().HasColumnType("varchar(30)");
            builder.Property(u => u.Password).IsRequired().HasColumnType("varchar(60)");
            builder.Property(u => u.Email).IsRequired().HasColumnType("varchar(60)");
        }
    }
}
