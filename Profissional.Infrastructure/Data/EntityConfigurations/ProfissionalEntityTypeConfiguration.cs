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

        builder.Property(e => e.UrlAmigavel);

        builder.Property(e => e.Sobre);

        builder.Property(e => e.UnidadeId);

        builder.Property(e => e.ImagemUrlPerfil);

        builder.Property(e => e.Conselho);

        builder.Property(e => e.NumeroIdentificacao);

        builder.Property(e => e.Telefone);

        builder.Property(e => e.Celular);

        builder.Property(e => e.Email);

        builder.Property(e => e.Site);

        builder.Property(e => e.Facebook);

        builder.Property(e => e.Instagram);

        builder.Property(e => e.Youtube);

        builder.Property(e => e.Linkedin);

        builder.Property(e => e.Recomendado);

        builder.Property(e => e.Status);

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