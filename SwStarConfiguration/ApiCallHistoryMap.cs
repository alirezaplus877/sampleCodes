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
    public class ApiCallHistoryMap : IEntityTypeConfiguration<ApiCallHistory>
    {
        public void Configure(EntityTypeBuilder<ApiCallHistory> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_ApiCallHistory");

            entity.ToTable("_ApiCallHistory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ApiResponseTime).HasColumnType("datetime");
            entity.Property(e => e.CallTime).HasColumnType("datetime");

            entity.HasOne(d => d.Api).WithMany(p => p.ApiCallHistories)
                .HasForeignKey(d => d.ApiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApiCallHistory_ApiInfo");
        }
    }
}
