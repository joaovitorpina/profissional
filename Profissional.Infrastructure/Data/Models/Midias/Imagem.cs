using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Infrastructure.Data.Models.Midias;

public class Imagem : MidiaAbstract
{
    private Imagem()
    {
    }

    public Imagem(Profissional profissional, string titulo, string url) : base(profissional, titulo, url,
        TipoMidiaEnum.Imagem)
    {
    }
}