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
    internal class ResultCodeMap : IEntityTypeConfiguration<ResultCode>
    {
        public void Configure(EntityTypeBuilder<ResultCode> entity)
        {
            entity.ToTable("ResultCode");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.TitleEn)
                .HasMaxLength(50)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleFa)
                .HasMaxLength(50)
                .HasColumnName("TitleFA");
        }
    }
}
