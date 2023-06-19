using Entities.PgwEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.PgwConfiguration
{
    public class _MerchantMap : IEntityTypeConfiguration<_Merchant>
    {
        public void Configure(EntityTypeBuilder<_Merchant> builder)
        {
            builder.ToTable("Merchant", "dbo");
            builder.HasKey(p => p.Id);
        }
    }
}
