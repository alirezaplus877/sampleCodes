﻿using Entities.SwStar;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SwStarConfiguration
{
    internal class ProcessCodeMap : IEntityTypeConfiguration<ProcessCode>
    {
        public void Configure(EntityTypeBuilder<ProcessCode> entity)
        {
            entity.ToTable("ProcessCode");

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
