using Profissionais.App.DTO;

namespace Profissionais.App.Ports;

public interface IBuscarProfissionalPorIdQueryService
{
    public Task<BuscarProfissionalPorIdResponse?> BuscarProfissionalPorId(int id);
}