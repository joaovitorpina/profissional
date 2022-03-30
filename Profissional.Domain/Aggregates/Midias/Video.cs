namespace Profissional.Domain.Aggregates.Midias;

public class Video : MidiaAbstract
{
    public Video(string titulo, string url, string urlThumbnail) : base(titulo, url, TipoMidia.Video)
    {
        UrlThumbnail = urlThumbnail;
    }

    public string UrlThumbnail { get; }
}