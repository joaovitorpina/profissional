using MediatR;
using Profissionais.App.Commands;
using Profissionais.App.Ports;
using Profissional.Domain.Exceptions;

namespace Profissionais.App.CommandHandlers;

public class RemoverConvenioCommandHandler : IRequestHandler<RemoverConvenioCommand, List<string>>
{
    public RemoverConvenioCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<List<string>> Handle(RemoverConvenioCommand request, CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.ProfissionalId);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.RemoverConvenio(request.Descricao);
        profissional = await ProfissionalRepository.Alterar(profissional);

        return profissional.Convenios.ToList();
    }
}