using Profissionais.App.DTO;

namespace Profissionais.App.Ports;

public interface IBuscarTiposProfissionalQueryService
{
    Task<List<BuscarTiposProfissionalResponse>> BuscarTiposProfissional();
}