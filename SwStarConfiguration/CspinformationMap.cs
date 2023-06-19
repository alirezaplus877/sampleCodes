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
    internal class CspinformationMap : IEntityTypeConfiguration<Cspinformation>
    {
        public void Configure(EntityTypeBuilder<Cspinformation> entity)
        {
            entity.ToTable("CSPInformation");

            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.EconomicId)
                .HasMaxLength(50)
                .HasComment("شناسه اقتصادی");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LicenseId).HasComment("شماره مجوز");
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.TitleEn)
                .HasMaxLength(250)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleFa)
                .HasMaxLength(250)
                .HasColumnName("TitleFA");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.Url)
                .HasMaxLength(250)
                .HasColumnName("URL");

            entity.HasOne(d => d.City).WithMany(p => p.Cspinformations)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CSPInformation_City");

            entity.HasOne(d => d.License).WithMany(p => p.Cspinformations)
                .HasForeignKey(d => d.LicenseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CSPInformation_CSPLicense");

            entity.HasOne(d => d.Province).WithMany(p => p.Cspinformations)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CSPInformation_Province");
        }
    }
}
