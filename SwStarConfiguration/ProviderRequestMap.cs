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
    internal class ProviderRequestMap : IEntityTypeConfiguration<ProviderRequest>
    {
        public void Configure(EntityTypeBuilder<ProviderRequest> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_Request");

            entity.ToTable("ProviderRequest");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AdditionaData).HasMaxLength(50);
            entity.Property(e => e.Apiid).HasColumnName("APIId");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.TrackingNumber).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Api).WithMany(p => p.ProviderRequests)
                .HasForeignKey(d => d.Apiid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_ApiInfo");

            entity.HasOne(d => d.Contract).WithMany(p => p.ProviderRequests)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK_ProviderRequest_Contract");

            entity.HasOne(d => d.Provider).WithMany(p => p.ProviderRequests)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Request_Provider");
        }
    }
}
