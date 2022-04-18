using MediatR;
using Profissionais.App.DTO;

namespace Profissionais.App.Queries;

public class BuscarTiposProfissionalQuery : IRequest<List<BuscarTiposProfissionalResponse>>
{
}