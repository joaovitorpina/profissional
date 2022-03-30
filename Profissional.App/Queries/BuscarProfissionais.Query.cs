using MediatR;
using Profissionais.App.DTO;

namespace Profissionais.App.Queries;

public class BuscarProfissionaisQuery : IRequest<BuscarProfissionaisResponse>
{
    public int Pagina { get; set; } = 1;
    public int Limite { get; set; } = 5;
    public int? UnidadeId { get; set; }
    public string? Nome { get; set; }
    public int? TipoProfissionalId { get; set; }
    public int? EspecialidadeId { get; set; }
}