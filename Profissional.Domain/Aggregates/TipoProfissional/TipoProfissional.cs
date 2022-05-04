using Profissional.Domain.Events;
using Profissional.Domain.SeedWork;

namespace Profissional.Domain.Aggregates.TipoProfissional;

public class TipoProfissional : Entity, IAggregateRoot
{
    private readonly HashSet<Especialidade> _especialidades;

    private TipoProfissional()
    {
        _especialidades = new HashSet<Especialidade>();
    }

    public TipoProfissional(string descricao) : this()
    {
        Descricao = descricao;
    }

    public string Descricao { get; set; }

    public IReadOnlySet<Especialidade> Especialidades => _especialidades;

    public void AdicionarEspecialidade(Especialidade especialidade)
    {
        _especialidades.Add(especialidade);
    }

    public void RemoverEspecialidade(Especialidade especialidade)
    {
        _especialidades.Remove(especialidade);
        AddDomainEvent(new EspecialidadeRemovidaEvent(especialidade, this));
    }
}