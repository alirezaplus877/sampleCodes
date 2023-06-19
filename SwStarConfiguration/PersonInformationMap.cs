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
    internal class PersonInformationMap : IEntityTypeConfiguration<PersonInformation>
    {
        public void Configure(EntityTypeBuilder<PersonInformation> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_PersonInformation");

            entity.ToTable("_PersonInformation");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EconomicCode).HasMaxLength(50);
            entity.Property(e => e.IdentifyCode).HasMaxLength(50);
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.TaxCode).HasMaxLength(50);
            entity.Property(e => e.TitleEn)
                .HasMaxLength(250)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleFa)
                .HasMaxLength(250)
                .HasColumnName("TitleFA");

            entity.HasOne(d => d.City).WithMany(p => p.PersonInformations)
                .HasForeignKey(d => d.CityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonInformation_City");

            entity.HasOne(d => d.IdentifyTypeNavigation).WithMany(p => p.PersonInformations)
                .HasForeignKey(d => d.IdentifyType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonInformation_IdentifyType");

            entity.HasOne(d => d.PersonType).WithMany(p => p.PersonInformations)
                .HasForeignKey(d => d.PersonTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonInformation_PersonType");

            entity.HasOne(d => d.Province).WithMany(p => p.PersonInformations)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PersonInformation_Province");
        }
    }
}
