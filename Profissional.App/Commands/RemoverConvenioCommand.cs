using MediatR;

namespace Profissionais.App.Commands;

public class RemoverConvenioCommand : IRequest<List<string>>
{
    public RemoverConvenioCommand(int profissionalId, string descricao)
    {
        ProfissionalId = profissionalId;
        Descricao = descricao;
    }

    public int ProfissionalId { get; }
    public string Descricao { get; }
}