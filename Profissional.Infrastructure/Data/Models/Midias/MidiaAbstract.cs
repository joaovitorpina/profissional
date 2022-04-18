using System.ComponentModel.DataAnnotations;
using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Infrastructure.Data.Models.Midias;

public abstract class MidiaAbstract
{
    protected MidiaAbstract()
    {
    }

    public MidiaAbstract(ProfissionalModel profissionalModel, string titulo, string url, TipoMidiaEnum tipoMidia)
    {
        ProfissionalModel = profissionalModel;
        Titulo = titulo;
        Url = url;
        TipoMidia = tipoMidia;
    }

    [Key] public int ProfissionalId { get; set; }

    public ProfissionalModel ProfissionalModel { get; set; }
    public string Titulo { get; set; }
    public string Url { get; set; }
    public TipoMidiaEnum TipoMidia { get; set; }
}