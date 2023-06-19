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
    internal class SettelmentMap : IEntityTypeConfiguration<Settelment>
    {
        public void Configure(EntityTypeBuilder<Settelment> entity)
        {
            entity.ToTable("Settelment");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.InsertDate).HasColumnType("datetime");
            entity.Property(e => e.RefrenceNumber).HasComment("شماره مرجع");
            entity.Property(e => e.SettlementDate).HasColumnType("datetime");
            entity.Property(e => e.State).HasComment("وضعیت قسط");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        }
    }
}
