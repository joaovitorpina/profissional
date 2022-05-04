using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Infrastructure.Data.EntityConfigurations;

public class ImagemEntityTypeConfiguration : IEntityTypeConfiguration<Imagem>
{
    public void Configure(EntityTypeBuilder<Imagem> builder)
    {
        builder.HasBaseType(typeof(MidiaAbstract));
    }
}