using Entities.SwStar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.SwStarConfiguration
{
    public class AccountTypeMap : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> entity)
        {
           
                entity.ToTable("AccountType");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.TitleEn)
                    .HasMaxLength(50)
                    .HasColumnName("TitleEN");
                entity.Property(e => e.TitleFa)
                    .HasMaxLength(50)
                    .HasColumnName("TitleFA");
           
        }
    }
}
