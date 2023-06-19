using Entities.SwStar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.SwStarConfiguration
{
    public class AccountMap : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entity)
        {
            entity.ToTable("Account");

            entity.Property(e => e.AccontIdentifier)
                .HasMaxLength(50)
                .HasComment("شناسه حساب");
            entity.Property(e => e.AccountType).HasComment("نوع حساب");
            entity.Property(e => e.Cspid).HasColumnName("CSPId");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("updateDate");

            entity.HasOne(d => d.AccountTypeNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.AccountType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_AccountType");

            entity.HasOne(d => d.Csp).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Cspid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_CSPInformation");

            entity.HasOne(d => d.Customer).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Customer");

            entity.HasOne(d => d.Merchant).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.MerchantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Account_Merchant");

        }
    }
}
