using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
   
    public class PGWUserClaimMap : IEntityTypeConfiguration<PGWUserClaim>
    {
        public void Configure(EntityTypeBuilder<PGWUserClaim> builder)
        {
            builder.ToTable("UserClaim", "dbo");
            builder.HasKey(o => o.Id);
            //builder.Property(t => t.CustomerName).HasMaxLength(50);
            //builder.Property(t => t.CustomerLastName).HasMaxLength(50);
        }
    }
}
