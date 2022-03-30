using MediatR;
using Profissionais.App.DTO;
using Profissionais.App.Ports;
using Profissionais.App.Queries;

namespace Profissionais.App.QueryHandlers;

public class BuscarProfissionaisQueryHandler : IRequestHandler<BuscarProfissionaisQuery, BuscarProfissionaisResponse>
{
    public BuscarProfissionaisQueryHandler(IBuscarProfissionaisQueryService buscarProfissionaisQueryService)
    {
        BuscarProfissionaisQueryService = buscarProfissionaisQueryService;
    }

    private IBuscarProfissionaisQueryService BuscarProfissionaisQueryService { get; }

    public async Task<BuscarProfissionaisResponse> Handle(BuscarProfissionaisQuery request,
        CancellationToken cancellationToken)
    {
        var result = await BuscarProfissionaisQueryService.BuscarProfissionais(request);

        return result;
    }
}