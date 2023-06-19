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
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> entity)
        {
            entity.ToTable("City");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CityEntitle)
                .HasMaxLength(50)
                .HasColumnName("CityENTitle");
            entity.Property(e => e.CityFatitle)
                .HasMaxLength(50)
                .HasColumnName("CityFATitle");
        }
    }
}
