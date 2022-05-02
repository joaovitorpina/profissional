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
            : await CriarTipoProfissional(request);

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

        var especialidades = await MontarEspecialidades(request.Especialidades, tipoProfissional.Id);

        foreach (var tipoProfissionalEspecialidade in tipoProfissional.Especialidades)
            if (!especialidades.Contains(tipoProfissionalEspecialidade))
                tipoProfissional.RemoverEspecialidade(tipoProfissionalEspecialidade);

        foreach (var especialidade in especialidades.Where(especialidade =>
                     !tipoProfissional.Especialidades.Contains(especialidade)))
            tipoProfissional.AdicionarEspecialidade(especialidade);

        return tipoProfissional;
    }

    private async Task<List<Especialidade>> MontarEspecialidades(List<string> especialidades, int tipoProfissionalId)
    {
        var especialidadesDomain = new List<Especialidade>();

        foreach (var especialidade in especialidades)
        {
            var especialidadeDomain =
                await TipoProfissionalRepository.BuscarEspecialidadePorDescricao(especialidade, tipoProfissionalId);

            especialidadesDomain.Add(especialidadeDomain ?? new Especialidade(especialidade));
        }

        return especialidadesDomain;
    }

    private async Task<TipoProfissional> CriarTipoProfissional(SalvarTipoProfissionalCommand request)
    {
        var especialidades = await MontarEspecialidades(request.Especialidades, 0);

        // return new TipoProfissional(request.Descricao, especialidades.ToHashSet());
        return null;
    }
}