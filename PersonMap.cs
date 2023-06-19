using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(t => t.Name).HasMaxLength(50);
            builder.Property(t => t.LastName).HasMaxLength(50);
        }
    }
}
