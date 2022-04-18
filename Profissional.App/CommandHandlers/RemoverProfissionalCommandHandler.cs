using MediatR;
using Profissionais.App.Commands;
using Profissionais.App.Ports;
using Profissional.Domain.Exceptions;

namespace Profissionais.App.CommandHandlers;

public class RemoverProfissionalCommandHandler : IRequestHandler<RemoverProfissionalCommand>
{
    public RemoverProfissionalCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<Unit> Handle(RemoverProfissionalCommand request, CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.Id);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        await ProfissionalRepository.Remover(profissional);

        return Unit.Value;
    }
}