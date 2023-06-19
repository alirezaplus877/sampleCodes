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
    internal class CsplicenseMap : IEntityTypeConfiguration<Csplicense>
    {
        public void Configure(EntityTypeBuilder<Csplicense> entity)
        {
            entity.ToTable("CSPLicense");

            //entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IssueDate).HasColumnType("date");
            entity.Property(e => e.LicenseIdentifier).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.ValidityDate).HasColumnType("date");
        }
    }
}
