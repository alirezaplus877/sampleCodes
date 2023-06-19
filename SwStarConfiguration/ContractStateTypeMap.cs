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
    internal class ContractStateTypeMap : IEntityTypeConfiguration<ContractStateType>
    {
        public void Configure(EntityTypeBuilder<ContractStateType> entity)
        {
            entity.ToTable("ContractStateType");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.TitleEn)
                .HasMaxLength(50)
                .HasColumnName("TitleEN");
            entity.Property(e => e.TitleFa)
                .HasMaxLength(50)
                .HasColumnName("TitleFA");
        }
    }
}
