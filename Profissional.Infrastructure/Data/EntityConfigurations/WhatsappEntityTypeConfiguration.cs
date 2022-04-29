using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profissional.Domain.Aggregates.Profissional;

namespace Profissional.Infrastructure.Data.EntityConfigurations;

public class WhatsappEntityTypeConfiguration : IEntityTypeConfiguration<Whatsapp>
{
    public void Configure(EntityTypeBuilder<Whatsapp> builder)
    {
        builder.ToTable("whatsapps");

        builder.HasKey(e => new { e.Numero, e.Principal });

        builder.Property(e => e.Numero).IsRequired();

        builder.Property(e => e.Principal).IsRequired();
    }
}