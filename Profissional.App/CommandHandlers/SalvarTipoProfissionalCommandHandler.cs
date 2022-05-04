using MediatR;
using Profissionais.App.Commands;
using Profissionais.App.DTO;
using Profissionais.App.Exceptions;
using Profissionais.App.Ports;
using Profissional.Domain.Aggregates.TipoProfissional;

namespace Profissionais.App.CommandHandlers;

public class
    SalvarTipoProfissionalCommandHandler : IRequestHandler<SalvarTipoProfissionalCommand,
        SalvarTipoProfissionalResponse>
{
    public SalvarTipoProfissionalCommandHandler(ITipoProfissionalRepository tipoProfissionalRepository)
    {
        TipoProfissionalRepository = tipoProfissionalRepository;
    }

    private ITipoProfissionalRepository TipoProfissionalRepository { get; }

    public async Task<SalvarTipoProfissionalResponse> Handle(SalvarTipoProfissionalCommand request,
        CancellationToken cancellationToken)
    {
        var tipoProfissional = request.Id is not null
            ? await AtualizarTipoProfissional(request)
            : CriarTipoProfissional(request);

        tipoProfissional = await TipoProfissionalRepository.Salvar(tipoProfissional);

        return new SalvarTipoProfissionalResponse(tipoProfissional.Id, tipoProfissional.Descricao,
            tipoProfissional.Especialidades.Select(especialidade =>
                new SalvarTipoProfissionalEspecialidadeResponse(especialidade.Id, especialidade.Descricao)).ToList());
    }

    private async Task<TipoProfissional> AtualizarTipoProfissional(SalvarTipoProfissionalCommand request)
    {
        var tipoProfissional = await TipoProfissionalRepository.BuscarPorId(request.Id!.Value);

        if (tipoProfissional is null) throw new TipoProfissionalNaoEncontradoException();

        tipoProfissional.Descricao = request.Descricao;

        //TODO Rever essa parte de exclusao de especialidades nao mais presentes
        // foreach (var tipoProfissionalEspecialidade in tipoProfissional.Especialidades)
        //     if (!especialidades.Contains(tipoProfissionalEspecialidade))
        //         tipoProfissional.RemoverEspecialidade(tipoProfissionalEspecialidade);

        foreach (var especialidade in request.Especialidades)
            tipoProfissional.AdicionarEspecialidade(new Especialidade(especialidade));

        return tipoProfissional;
    }

    private void AdicionarEspecialidades(TipoProfissional tipoProfissional, List<string> especialidades)
    {
        foreach (var especialidade in especialidades)
        {
            tipoProfissional.AdicionarEspecialidade(new Especialidade(especialidade));
        }
    }

    private TipoProfissional CriarTipoProfissional(SalvarTipoProfissionalCommand request)
    {
        var tipoProfissional = new TipoProfissional(request.Descricao);
        AdicionarEspecialidades(tipoProfissional, request.Especialidades);

        return tipoProfissional;
    }
}