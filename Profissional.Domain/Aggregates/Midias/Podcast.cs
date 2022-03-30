namespace Profissional.Domain.Aggregates.Midias;

public class Podcast : MidiaAbstract
{
    public Podcast(string titulo, string url) : base(titulo, url, TipoMidia.Podcast)
    {
    }
}