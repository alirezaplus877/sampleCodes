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
    internal class SubProcessCodeMap : IEntityTypeConfiguration<SubProcessCode>
    {
        public void Configure(EntityTypeBuilder<SubProcessCode> entity)
        {
            entity.ToTable("SubProcessCode");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TitleEn)
                .HasMaxLength(50)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleFa)
                .HasMaxLength(50)
                .HasColumnName("TitleFA");

            entity.HasOne(d => d.Process).WithMany(p => p.SubProcessCodes)
                .HasForeignKey(d => d.ProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubProcessCode_ProcessCode");
        }
    }
}
