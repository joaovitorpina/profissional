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

        builder.Ignore(e => e.Midias);

        builder.HasOne(e => e.TipoProfissional)
            .WithMany()
            .HasForeignKey("tipo_profissional_id");

        builder.OwnsOne(e => e.Endereco, b =>
        {
            b.Property(e => e.Bairro);

            b.Property(e => e.Logradouro);

            b.Property(e => e.Numero);

            b.Property(e => e.Cidade).IsRequired();

            b.Property(e => e.Estado).IsRequired();

            b.Property(e => e.Cep);
        });

        builder.OwnsMany(e => e.Tratamentos, b =>
        {
            b.ToTable("tratamentos");

            b.Property(e => e.Descricao).IsRequired();
        });

        builder.OwnsMany(e => e.Convenios, b =>
        {
            b.ToTable("convenios");

            b.Property(e => e.Descricao).IsRequired();
        });

        builder.HasMany(e => e.Especialidades)
            .WithMany(e => e.Profissionais);

        builder.HasMany(e => e.Midias)
            .WithOne();

        builder.OwnsMany(e => e.Whatsapps, b =>
        {
            b.Property(e => e.Numero).IsRequired();

            b.Property(e => e.Principal).IsRequired();
        });

        var navigation =
            builder.Metadata.FindNavigation(nameof(Domain.Aggregates.Profissional.Profissional.Especialidades));
        navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
    }
}