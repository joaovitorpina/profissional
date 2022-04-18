using Profissional.Domain.Aggregates.Midias;
using Profissional.Infrastructure.Data.Models;
using Imagem = Profissional.Infrastructure.Data.Models.Midias.Imagem;
using Podcast = Profissional.Infrastructure.Data.Models.Midias.Podcast;
using Video = Profissional.Infrastructure.Data.Models.Midias.Video;

namespace Profissional.Infrastructure.Data.Mappers;

public static class MidiaMapper
{
    public static MidiaAbstract ToDomain(Models.Midias.MidiaAbstract model)
    {
        return model switch
        {
            Imagem imagem => new Domain.Aggregates.Midias.Imagem(imagem.Titulo, imagem.Url),
            Podcast podcast => new Domain.Aggregates.Midias.Podcast(podcast.Titulo, podcast.Url),
            Video video => new Domain.Aggregates.Midias.Video(video.Titulo, video.Url, video.UrlThumbnail),
            _ => throw new ArgumentOutOfRangeException(nameof(model))
        };
    }

    public static Models.Midias.MidiaAbstract ToModel(MidiaAbstract domain, ProfissionalModel profissionalModel)
    {
        return domain switch
        {
            Domain.Aggregates.Midias.Imagem imagem => new Imagem(profissionalModel, imagem.Titulo, imagem.Url),
            Domain.Aggregates.Midias.Podcast podcast => new Podcast(profissionalModel, podcast.Titulo, podcast.Url),
            Domain.Aggregates.Midias.Video video => new Video(profissionalModel, video.Titulo, video.Url,
                video.UrlThumbnail),
            _ => throw new ArgumentOutOfRangeException(nameof(domain))
        };
    }
}