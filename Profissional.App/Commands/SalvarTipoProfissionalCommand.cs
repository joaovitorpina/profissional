using MediatR;
using Profissionais.App.DTO;

namespace Profissionais.App.Commands;

public class SalvarTipoProfissionalCommand : IRequest<SalvarTipoProfissionalResponse>
{
    public SalvarTipoProfissionalCommand(int? id, string descricao, List<string> especialidades)
    {
        Id = id;
        Descricao = descricao;
        Especialidades = especialidades;
    }

    public int? Id { get; }
    public string Descricao { get; }
    public List<string> Especialidades { get; }
}