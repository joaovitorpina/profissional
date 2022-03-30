using System.ComponentModel.DataAnnotations;
using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Infrastructure.Data.Models.Midias;

public abstract class MidiaAbstract
{
    protected MidiaAbstract()
    {
    }

    public MidiaAbstract(Profissional profissional, string titulo, string url, TipoMidiaEnum tipoMidia)
    {
        Profissional = profissional;
        Titulo = titulo;
        Url = url;
        TipoMidia = tipoMidia;
    }

    [Key] public int ProfissionalId { get; set; }

    public Profissional Profissional { get; set; }
    public string Titulo { get; set; }
    public string Url { get; set; }
    public TipoMidiaEnum TipoMidia { get; set; }
}