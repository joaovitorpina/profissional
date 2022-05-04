using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profissional.Domain.Aggregates.Profissional;

namespace Profissional.Infrastructure.Data.EntityConfigurations;

public class ConvenioEntityTypeConfiguration : IEntityTypeConfiguration<Convenio>
{
    public void Configure(EntityTypeBuilder<Convenio> builder)
    {
        builder.ToTable("convenios");

        builder.Property(e => e.Descricao).IsRequired();
    }
}