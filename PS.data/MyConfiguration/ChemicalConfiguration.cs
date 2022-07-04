using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PS.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PS.data.MyConfiguration
{
    public class ChemicalConfiguration : IEntityTypeConfiguration<Chemical>
    {
     

        public void Configure(EntityTypeBuilder<Chemical> builder)
        {
            builder.OwnsOne(c => c.Adresse, myadd =>
            {
                myadd.Property(a =>
                a.StreetAdress).HasColumnName("MyStreet").HasMaxLength(50);
                myadd.Property(a => a.City).HasColumnName("MyCity").IsRequired();
            });
        }
    }
}
