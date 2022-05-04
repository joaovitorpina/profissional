using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profissional.Domain.Aggregates.TipoProfissional;

namespace Profissional.Infrastructure.Data.EntityConfigurations;

public class EspecialidadeEntityTypeConfiguration : IEntityTypeConfiguration<Especialidade>
{
    public void Configure(EntityTypeBuilder<Especialidade> builder)
    {
        builder.ToTable("especialidades");

        builder.HasKey(e => e.Id);

        builder.Ignore(e => e.DomainEvents);

        builder.Property(e => e.Descricao).IsRequired();
    }
}