using Profissional.Domain.SeedWork;

namespace Profissional.Domain.Aggregates.TipoProfissional;

public class Especialidade : Entity
{
    public Especialidade(string descricao, int id = default) : base(id)
    {
        Descricao = descricao;
    }

    public string Descricao { get; }

    public void InserirId(int id)
    {
    }
}