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
    internal class TransactionMap : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> entity)
        {
            entity.HasKey(e => e.RefrenceNumber1);

            entity.ToTable("Transaction");

            entity.HasIndex(e => e.RefrenceNumber1, "IX_Transaction").IsUnique();

            entity.Property(e => e.RefrenceNumber1).ValueGeneratedNever();
            entity.Property(e => e.Cspid).HasColumnName("CSPID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.MerchantId).HasColumnName("MerchantID");
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.SwDate)
                .HasColumnType("date")
                .HasColumnName("swDate");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.ProcessCodeNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ProcessCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_ProcessCode");

            entity.HasOne(d => d.RefrenceNumber1Navigation).WithOne(p => p.Transaction)
                .HasForeignKey<Transaction>(d => d.RefrenceNumber1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_Settelment");

            entity.HasOne(d => d.ResponseCodeNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.ResponseCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_ResultCode");

            entity.HasOne(d => d.SubProcessCodeNavigation).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.SubProcessCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transaction_SubProcessCode");
        }
    }
}
