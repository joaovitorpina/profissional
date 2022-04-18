using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Infrastructure.Data.Models.Midias;

public class Imagem : MidiaAbstract
{
    private Imagem()
    {
    }

    public Imagem(ProfissionalModel profissionalModel, string titulo, string url) : base(profissionalModel, titulo, url,
        TipoMidiaEnum.Imagem)
    {
    }
}