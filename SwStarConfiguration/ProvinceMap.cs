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
    internal class ProvinceMap : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> entity)
        {
            entity.ToTable("Province");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ProvinceEntitle)
                .HasMaxLength(50)
                .HasColumnName("ProvinceENTitle");
            entity.Property(e => e.ProvinceFatitle)
                .HasMaxLength(50)
                .HasColumnName("ProvinceFATitle");
        }
    }
}
