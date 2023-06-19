using Entities.PgwEntities;
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
    internal class MerchantMap : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> entity)
        {
            entity.ToTable("Merchant");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.EconomyId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("شناسه مالیاتی (TaxCode)");
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.ExpireDate)
                .HasComment("تاریخ انقضا")
                .HasColumnType("datetime");
            entity.Property(e => e.Family).HasMaxLength(50);
            entity.Property(e => e.InsertDateTime)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Mccode)
                .HasComment("کد صنف")
                .HasColumnName("MCCode");
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.NationalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.PostalCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Tel)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Type).HasComment("حقیقی و حقوقی");
            entity.Property(e => e.UpdateDatetime).HasColumnType("datetime");

            entity.HasOne(d => d.CityNavigation).WithMany(p => p.Merchants)
                .HasForeignKey(d => d.City)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Merchant_City");

            entity.HasOne(d => d.MccodeNavigation).WithMany(p => p.Merchants)
                .HasForeignKey(d => d.Mccode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Merchant_MerchantCategoryCode");

            entity.HasOne(d => d.ProvinceNavigation).WithMany(p => p.Merchants)
                .HasForeignKey(d => d.Province)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Merchant_Province");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Merchants)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Merchant_CustomerType");
        }
    }
}
