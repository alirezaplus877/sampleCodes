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
    internal class IpwhiteListMap : IEntityTypeConfiguration<IpwhiteList>
    {
        public void Configure(EntityTypeBuilder<IpwhiteList> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_IPWhiteList");

            entity.ToTable("_IPWhiteList");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.EndRange)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.StartRange)
                .HasMaxLength(50)
                .IsUnicode(false)
                .IsFixedLength();
        }
    }
}
