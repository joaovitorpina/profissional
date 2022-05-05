using Microsoft.EntityFrameworkCore;
using Profissional.Domain.Aggregates.Midias;
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
    public DbSet<TipoMidia> TiposMidia => Set<TipoMidia>();

    //TODO Ajustar a connection string
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseMySql("server=mysql;database=profissionais;user=root;password=root",
                ServerVersion.Parse("8.0.28-mysql")).UseSnakeCaseNamingConvention();
        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new EspecialidadeEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new MidiaAbstractEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TipoMidiaEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ImagemEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new PodcastEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new VideoEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new ProfissionalEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new TipoProfissionalEntityTypeConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}