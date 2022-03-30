using MediatR;
using Profissionais.App.DTO;
using Profissionais.App.Ports;
using Profissionais.App.Queries;
using Profissional.Domain.Exceptions;

namespace Profissionais.App.QueryHandlers;

public class BuscarProfissionalPorUrlAmigavelQueryHandler : IRequestHandler<BuscarProfissionalPorUrlAmigavelQuery,
    BuscarProfissionalPorUrlAmigavelResponse>
{
    public BuscarProfissionalPorUrlAmigavelQueryHandler(
        IBuscarProfissionalPorUrlAmigavelQueryService buscarProfissionalPorUrlAmigavelQueryService)
    {
        BuscarProfissionalPorUrlAmigavelQueryService = buscarProfissionalPorUrlAmigavelQueryService;
    }

    private IBuscarProfissionalPorUrlAmigavelQueryService BuscarProfissionalPorUrlAmigavelQueryService { get; }

    public async Task<BuscarProfissionalPorUrlAmigavelResponse> Handle(BuscarProfissionalPorUrlAmigavelQuery request,
        CancellationToken cancellationToken)
    {
        var profissional =
            await BuscarProfissionalPorUrlAmigavelQueryService.BuscarProfissionalPorUrlAmigavel(request.UrlAmigavel);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        return profissional;
    }
}