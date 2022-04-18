using MediatR;
using Profissionais.App.DTO;
using Profissionais.App.Ports;
using Profissionais.App.Queries;

namespace Profissionais.App.QueryHandlers;

public class
    BuscarTiposProfissionalQueryHandler : IRequestHandler<BuscarTiposProfissionalQuery,
        List<BuscarTiposProfissionalResponse>>
{
    public BuscarTiposProfissionalQueryHandler(IBuscarTiposProfissionalQueryService buscarTiposProfissionalQueryService)
    {
        BuscarTiposProfissionalQueryService = buscarTiposProfissionalQueryService;
    }

    private IBuscarTiposProfissionalQueryService BuscarTiposProfissionalQueryService { get; }

    public async Task<List<BuscarTiposProfissionalResponse>> Handle(BuscarTiposProfissionalQuery request,
        CancellationToken cancellationToken)
    {
        return await BuscarTiposProfissionalQueryService.BuscarTiposProfissional();
    }
}