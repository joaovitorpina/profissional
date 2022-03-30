using MediatR;
using Profissionais.App.DTO;

namespace Profissionais.App.Queries;

public class BuscarProfissionalPorUrlAmigavelQuery : IRequest<BuscarProfissionalPorUrlAmigavelResponse>
{
    public BuscarProfissionalPorUrlAmigavelQuery(string urlAmigavel)
    {
        UrlAmigavel = urlAmigavel;
    }

    public string UrlAmigavel { get; }
}