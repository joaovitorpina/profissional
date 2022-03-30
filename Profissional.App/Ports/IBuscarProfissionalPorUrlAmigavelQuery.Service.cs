using Profissionais.App.DTO;

namespace Profissionais.App.Ports;

public interface IBuscarProfissionalPorUrlAmigavelQueryService
{
    public Task<BuscarProfissionalPorUrlAmigavelResponse?> BuscarProfissionalPorUrlAmigavel(string urlAmigavel);
}