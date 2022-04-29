using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profissional.Domain.Aggregates.Profissional;

namespace Profissional.Infrastructure.Data.EntityConfigurations;

public class EnderecoEntityTypeConfiguration : IEntityTypeConfiguration<Endereco>
{
    public void Configure(EntityTypeBuilder<Endereco> builder)
    {
        builder.ToTable("enderecos");

        builder.HasKey(e => new { e.Bairro, e.Cep, e.Cidade, e.Estado, e.Logradouro, e.Numero });

        builder.Property(e => e.Bairro);

        builder.Property(e => e.Logradouro);

        builder.Property(e => e.Numero);

        builder.Property(e => e.Cidade).IsRequired();

        builder.Property(e => e.Estado).IsRequired();

        builder.Property(e => e.Cep);
    }
}