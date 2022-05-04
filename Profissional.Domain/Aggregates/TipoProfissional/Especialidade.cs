using Profissional.Domain.SeedWork;

namespace Profissional.Domain.Aggregates.TipoProfissional;

public class Especialidade : Entity
{
    private readonly List<Profissional.Profissional> _profissionais;
    public readonly int tipoProfissionalId;

    private Especialidade()
    {
        _profissionais = new List<Profissional.Profissional>();
    }

    public Especialidade(string descricao) : this()
    {
        Descricao = descricao;
    }

    public string Descricao { get; }

    public IReadOnlyList<Profissional.Profissional> Profissionais => _profissionais;
}