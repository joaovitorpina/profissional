using MediatR;
using Profissionais.App.Commands;
using Profissionais.App.Ports;
using Profissional.Domain.Aggregates.Profissional;
using Profissional.Domain.Exceptions;

namespace Profissionais.App.CommandHandlers;

public class AdicionarConvenioCommandHandler : IRequestHandler<AdicionarConvenioCommand, List<string>>
{
    public AdicionarConvenioCommandHandler(IProfissionalRepository profissionalRepository)
    {
        ProfissionalRepository = profissionalRepository;
    }

    private IProfissionalRepository ProfissionalRepository { get; }

    public async Task<List<string>> Handle(AdicionarConvenioCommand request, CancellationToken cancellationToken)
    {
        var profissional = await ProfissionalRepository.BuscarPorId(request.ProfissionalId);

        if (profissional is null) throw new ProfissionalNaoEncontradoException();

        profissional.AdicionarConvenio(new Convenio(request.Descricao));
        profissional = await ProfissionalRepository.Alterar(profissional);

        return profissional.Tratamentos.Select(e => e.Descricao).ToList();
    }
}