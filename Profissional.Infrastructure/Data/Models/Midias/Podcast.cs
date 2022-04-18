using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Infrastructure.Data.Models.Midias;

public class Podcast : MidiaAbstract
{
    private Podcast()
    {
    }

    public Podcast(ProfissionalModel profissionalModel, string titulo, string url) : base(profissionalModel,
        titulo, url, TipoMidiaEnum.Podcast)
    {
    }
}