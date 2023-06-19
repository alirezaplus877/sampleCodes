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
    internal class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Product");

            //  entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IranCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Mccode)
                .HasComment("کد صنف")
                .HasColumnName("MCCode");
            entity.Property(e => e.SpecialCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength()
                .HasComment("کد اختصاصی کالا");
            entity.Property(e => e.TitleEn)
                .HasMaxLength(50)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleFa)
                .HasMaxLength(50)
                .HasColumnName("TitleFA");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_ProductCategory");

            entity.HasMany(d => d.Mccodes).WithMany(p => p.Products)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductInMcCode",
                    r => r.HasOne<MerchantCategoryCode>().WithMany()
                        .HasForeignKey("MccodeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductInMcCode_MerchantCategoryCode"),
                    l => l.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ProductInMcCode_Product"),
                    j =>
                    {
                        j.HasKey("ProductId", "MccodeId");
                        j.ToTable("ProductInMcCode");
                        j.IndexerProperty<int>("MccodeId").HasColumnName("MCCodeId");
                    });
        }
    }
}
