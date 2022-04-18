using MediatR;
using Profissionais.App.Commands;
using Profissionais.App.Ports;
using Profissional.Domain.Exceptions;

namespace Profissionais.App.CommandHandlers;

public class AdicionarTratamentoCommandHandler : IRequestHandler<AdicionarTratamentoCommand, List<string>>
{
    public AdicionarTratamentoCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<List<string>> Handle(AdicionarTratamentoCommand request, CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.ProfissionalId);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.AdicionarTratamento(request.Descricao);
        profissional = await ProfissionalRepository.Alterar(profissional);

        return profissional.Tratamentos.ToList();
    }
}