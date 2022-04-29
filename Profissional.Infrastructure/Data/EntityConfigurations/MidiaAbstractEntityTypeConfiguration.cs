using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Infrastructure.Data.EntityConfigurations;

public class MidiaAbstractEntityTypeConfiguration : IEntityTypeConfiguration<MidiaAbstract>
{
    public void Configure(EntityTypeBuilder<MidiaAbstract> builder)
    {
        builder.ToTable("midias");

        builder.HasKey(e => new { e.Titulo, e.Url, e.TipoMidia });

        builder.Property(e => e.Titulo).IsRequired();
        builder.Property(e => e.Url).IsRequired();
        builder.Property(e => e.TipoMidia).IsRequired();
    }
}