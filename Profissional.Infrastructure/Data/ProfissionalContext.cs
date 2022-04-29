using Microsoft.EntityFrameworkCore;
using Profissional.Domain.Aggregates.Midias;
using Profissional.Domain.Aggregates.Profissional;
using Profissional.Domain.Aggregates.TipoProfissional;
using Profissional.Infrastructure.Data.EntityConfigurations;

namespace Profissional.Infrastructure.Data;

public class ProfissionalContext : DbContext
{
    public DbSet<Domain.Aggregates.Profissional.Profissional> Profissionais =>
        Set<Domain.Aggregates.Profissional.Profissional>();

    public DbSet<TipoProfissional> TiposProfissional => Set<TipoProfissional>();
    public DbSet<Especialidade> Especialidades => Set<Especialidade>();
    public DbSet<MidiaAbstract> Midias => Set<MidiaAbstract>();
    public DbSet<Endereco> Enderecos => Set<Endereco>();
    public DbSet<Whatsapp> Whatsapps => Set<Whatsapp>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseMySql("server=localhost;database=profissionais;user=root;password=root",
                ServerVersion.Parse("8.0.28-mysql")).UseSnakeCaseNamingConvention();
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Imagem>();
        // modelBuilder.Entity<Podcast>();
        // modelBuilder.Entity<Video>();

        modelBuilder.ApplyConfiguration(new EnderecoEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new EspecialidadeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MidiaAbstractEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProfissionalEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TipoProfissionalEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new WhatsappEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}