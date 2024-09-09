using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuetuTech.GestaoDeBilhetes.Domain.Entities;

namespace TuetuTech.GestaoDeBilhetes.Persistence.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.Property(x => x.Nome).IsRequired()
                .HasMaxLength(50);
        }
    }
}
