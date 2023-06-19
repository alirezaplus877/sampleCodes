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
    public class ApiInfoMap : IEntityTypeConfiguration<ApiInfo>
    {
        public void Configure(EntityTypeBuilder<ApiInfo> entity)
        {
            entity.ToTable("ApiInfo");

            entity.Property(e => e.ApiBaseAddress).HasMaxLength(250);
            entity.Property(e => e.ApiName).HasMaxLength(50);
            entity.Property(e => e.ApiUrl).HasMaxLength(250);
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");

            entity.HasOne(d => d.Provider).WithMany(p => p.ApiInfos)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ApiInfo_Provider");
        }
    }
}
