using Profissional.Domain.SeedWork;

namespace Profissional.Domain.Aggregates.Midias;

public enum TipoMidiaEnum
{
    Imagem = 1,
    Video,
    Podcast
}

public class TipoMidia : Enumeration
{
    public static TipoMidia Imagem = new((int)TipoMidiaEnum.Imagem, "Imagem");
    public static TipoMidia Video = new((int)TipoMidiaEnum.Video, "Video");
    public static TipoMidia Podcast = new((int)TipoMidiaEnum.Podcast, "Podcast");

    public TipoMidia(int id, string name) : base(id, name)
    {
    }
}