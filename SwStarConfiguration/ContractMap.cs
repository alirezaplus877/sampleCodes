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
    internal class ContractMap : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> entity)
        {
            entity.ToTable("Contract");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.ContractDate).HasColumnType("datetime");
            entity.Property(e => e.ContractIndentifier).HasMaxLength(50);
            entity.Property(e => e.Cspid).HasColumnName("CSPId");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Csp).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.Cspid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_CSPInformation");

            entity.HasOne(d => d.Customer).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Customer");

            entity.HasOne(d => d.MerchantAccount).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.MerchantAccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Account");

            entity.HasOne(d => d.Merchant).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.MerchantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contract_Merchant");

            entity.HasOne(d => d.StateNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.State)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContractId_ContractStateType");
        }
    }
}
