using MediatR;

namespace Profissionais.App.Commands;

public class AdicionarTratamentoCommand : IRequest<List<string>>
{
    public AdicionarTratamentoCommand(int profissionalId, string descricao)
    {
        ProfissionalId = profissionalId;
        Descricao = descricao;
    }

    public int ProfissionalId { get; }
    public string Descricao { get; }
}