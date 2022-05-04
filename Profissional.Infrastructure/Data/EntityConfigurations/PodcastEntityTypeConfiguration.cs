using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Infrastructure.Data.EntityConfigurations;

public class PodcastEntityTypeConfiguration : IEntityTypeConfiguration<Podcast>
{
    public void Configure(EntityTypeBuilder<Podcast> builder)
    {
        builder.HasBaseType(typeof(MidiaAbstract));
    }
}