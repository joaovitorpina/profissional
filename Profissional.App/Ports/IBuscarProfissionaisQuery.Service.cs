using Profissionais.App.DTO;
using Profissionais.App.Queries;

namespace Profissionais.App.Ports;

public interface IBuscarProfissionaisQueryService
{
    public Task<BuscarProfissionaisResponse> BuscarProfissionais(BuscarProfissionaisQuery query);
}