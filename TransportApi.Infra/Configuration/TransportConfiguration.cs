using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportApi.Domain.Entities;

namespace TransportApi.Infra.Configuration
{
    internal sealed class TransportConfiguration : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.ToTable("Transports");

            builder.HasDiscriminator<TypeTransport>("TypeTransport")
                .HasValue<Airplane>(TypeTransport.Airplane)
                .HasValue<Car>(TypeTransport.Car);
        }
    }
}
