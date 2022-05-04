using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profissional.Domain.Aggregates.Profissional;

namespace Profissional.Infrastructure.Data.EntityConfigurations;

public class TratamentoEntityTypeConfiguration : IEntityTypeConfiguration<Tratamento>
{
    public void Configure(EntityTypeBuilder<Tratamento> builder)
    {
        builder.ToTable("tratamentos");

        builder.Property(e => e.Descricao).IsRequired();
    }
}