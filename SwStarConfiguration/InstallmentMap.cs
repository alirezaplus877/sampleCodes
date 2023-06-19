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
    internal class InstallmentMap : IEntityTypeConfiguration<Installment>
    {
        public void Configure(EntityTypeBuilder<Installment> entity)
        {
            entity.ToTable("Intallment");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.InstallmentDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Contract).WithMany(p => p.Intallments)
                .HasForeignKey(d => d.ContractId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Intallment_Contract");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.Intallments)
                .HasForeignKey(d => d.State)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Intallment_IntallmentState");
        }
    }
}
