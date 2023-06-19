using Entities.SwStar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SwStarConfiguration
{
    internal class MerchantCategoryCodeMap : IEntityTypeConfiguration<MerchantCategoryCode>
    {
        public void Configure(EntityTypeBuilder<MerchantCategoryCode> entity)
        {
            entity.ToTable("MerchantCategoryCode");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Mccode)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasComment("کد صنف")
                .HasColumnName("MCCode");
            entity.Property(e => e.SubMccode)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("SubMCCode");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(50)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleFa)
                .HasMaxLength(50)
                .HasColumnName("TitleFA");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        }
    }
}
