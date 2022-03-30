using Microsoft.EntityFrameworkCore;
using Profissional.Infrastructure.Data.Models;
using Profissional.Infrastructure.Data.Models.Midias;

namespace Profissional.Infrastructure.Data;

public class ProfissionalContext : DbContext
{
    public DbSet<Models.Profissional> Profissionais => Set<Models.Profissional>();
    public DbSet<TipoProfissional> TiposProfissional => Set<TipoProfissional>();
    public DbSet<Especialidade> Especialidades => Set<Especialidade>();
    public DbSet<MidiaAbstract> Midias => Set<MidiaAbstract>();
    public DbSet<Endereco> Enderecos => Set<Endereco>();
    public DbSet<Convenio> Convenios => Set<Convenio>();
    public DbSet<Tratamento> Tratamentos => Set<Tratamento>();
    public DbSet<Whatsapp> Whatsapps => Set<Whatsapp>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseMySql("server=localhost;database=profissionais;user=root;password=root",
                ServerVersion.Parse("8.0.28-mysql")).UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Imagem>();
        modelBuilder.Entity<Podcast>();
        modelBuilder.Entity<Video>();
        modelBuilder.Entity<MidiaAbstract>(entity =>
        {
            entity.HasKey(midia => new { midia.ProfissionalId, midia.Titulo, midia.Url, midia.TipoMidia });
        });

        modelBuilder.Entity<Tratamento>(entity =>
        {
            entity.HasKey(tratamento => new { tratamento.Descricao, tratamento.ProfissionalId });
        });

        modelBuilder.Entity<Convenio>(entity =>
        {
            entity.HasKey(convenio => new { convenio.ProfissionalId, convenio.Descricao });
        });

        modelBuilder.Entity<Whatsapp>(entity =>
        {
            entity.HasKey(whatsapp => new { whatsapp.ProfissionalId, whatsapp.Principal, whatsapp.Numero });
        });

        base.OnModelCreating(modelBuilder);
    }
}