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
    internal class InstallmentPaymentMap : IEntityTypeConfiguration<InstallmentPayment>
    {
        public void Configure(EntityTypeBuilder<InstallmentPayment> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_InstallmentPayment");

            entity.ToTable("_InstallmentPayment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PaymentDate).HasColumnType("datetime");
            entity.Property(e => e.Rrn).HasColumnName("RRN");
            entity.Property(e => e.SourceIdentifier).HasMaxLength(50);
            entity.Property(e => e.Txnstatus).HasColumnName("TXNStatus");

            entity.HasOne(d => d.Installment).WithMany(p => p.InstallmentPayments)
                .HasForeignKey(d => d.InstallmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_InstallmentPayment_Intallment");
        }
    }
}
