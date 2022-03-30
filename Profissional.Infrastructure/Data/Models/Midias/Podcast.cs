using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Infrastructure.Data.Models.Midias;

public class Podcast : MidiaAbstract
{
    private Podcast()
    {
    }

    public Podcast(Profissional profissional, string titulo, string url, TipoMidiaEnum tipoMidia) : base(profissional,
        titulo, url, tipoMidia)
    {
    }
}