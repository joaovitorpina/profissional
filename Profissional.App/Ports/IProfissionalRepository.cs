using Profissional.Domain.Aggregates.TipoProfissional;

namespace Profissionais.App.Ports;

public interface IProfissionalRepository
{
    public Task<Profissional.Domain.Aggregates.Profissional.Profissional> Criar(
        Profissional.Domain.Aggregates.Profissional.Profissional profissional);

    public Task<Profissional.Domain.Aggregates.Profissional.Profissional> Alterar(
        Profissional.Domain.Aggregates.Profissional.Profissional profissional);

    public Task Remover(Profissional.Domain.Aggregates.Profissional.Profissional profissional);

    public Task<Profissional.Domain.Aggregates.Profissional.Profissional?> BuscarPorId(int id);

    public Task<TipoProfissional?> BuscarTipoProfissional(int id);

    public Task<Especialidade?> BuscarEspecialidade(int id);
}