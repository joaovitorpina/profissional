using MediatR;
using Profissionais.App.DTO;
using Profissionais.App.Ports;
using Profissionais.App.Queries;
using Profissional.Domain.Exceptions;

namespace Profissionais.App.QueryHandlers;

public class
    BuscarProfissionalPorIdQueryHandler : IRequestHandler<BuscarProfissionalPorIdQuery, BuscarProfissionalPorIdResponse>
{
    public BuscarProfissionalPorIdQueryHandler(IBuscarProfissionalPorIdQueryService buscarProfissionalPorIdQueryService)
    {
        BuscarProfissionalPorIdQueryService = buscarProfissionalPorIdQueryService;
    }

    private IBuscarProfissionalPorIdQueryService BuscarProfissionalPorIdQueryService { get; }

    public async Task<BuscarProfissionalPorIdResponse> Handle(BuscarProfissionalPorIdQuery request,
        CancellationToken cancellationToken)
    {
        var profissional =
            await BuscarProfissionalPorIdQueryService.BuscarProfissionalPorId(request.Id);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        return profissional;
    }
}