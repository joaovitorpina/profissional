using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profissional.Domain.Aggregates.TipoProfissional;

namespace Profissional.Infrastructure.Data.EntityConfigurations;

public class TipoProfissionalEntityTypeConfiguration : IEntityTypeConfiguration<TipoProfissional>
{
    public void Configure(EntityTypeBuilder<TipoProfissional> builder)
    {
        builder.ToTable("tipos_profissional");

        builder.HasKey(e => e.Id);

        builder.Ignore(e => e.DomainEvents);

        builder.Property(e => e.Descricao).IsRequired();

        builder.HasMany(e => e.Especialidades)
            .WithOne()
            .HasForeignKey("tipo_profissional_id")
            .OnDelete(DeleteBehavior.Cascade);
    }
}