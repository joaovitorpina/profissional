using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Profissional.Infrastructure.Data.EntityConfigurations;

public class ProfissionalEntityTypeConfiguration : IEntityTypeConfiguration<Domain.Aggregates.Profissional.Profissional>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.Profissional.Profissional> builder)
    {
        builder.ToTable("profissionais");

        builder.HasKey(e => e.Id);

        builder.Ignore(e => e.DomainEvents);

        builder.Property(e => e.Nome);

        builder.HasOne(e => e.TipoProfissional)
            .WithMany()
            .HasForeignKey("tipo_profissional_id");

        builder.HasOne(e => e.Endereco)
            .WithOne();

        builder.HasMany(e => e.Tratamentos)
            .WithOne();

        builder.HasMany(e => e.Convenios)
            .WithOne();

        builder.HasMany(e => e.Especialidades)
            .WithOne();

        builder.HasMany(e => e.Whatsapps)
            .WithOne();
    }
}