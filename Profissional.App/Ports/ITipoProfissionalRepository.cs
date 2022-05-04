using Profissional.Domain.Aggregates.TipoProfissional;

namespace Profissionais.App.Ports;

public interface ITipoProfissionalRepository
{
    public Task<TipoProfissional?> BuscarPorId(int id);
    public Task<TipoProfissional> Salvar(TipoProfissional tipoProfissional);
}