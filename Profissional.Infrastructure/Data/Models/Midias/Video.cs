using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Infrastructure.Data.Models.Midias;

public class Video : MidiaAbstract
{
    private Video()
    {
    }

    public Video(Profissional profissional, string titulo, string url, string urlThumbnail) : base(profissional, titulo,
        url, TipoMidiaEnum.Video)
    {
        UrlThumbnail = urlThumbnail;
    }

    public string UrlThumbnail { get; set; }
}