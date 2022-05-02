using Profissional.Domain.Events;
using Profissional.Domain.SeedWork;

namespace Profissional.Domain.Aggregates.TipoProfissional;

public class TipoProfissional : Entity, IAggregateRoot
{
    private readonly HashSet<Especialidade> _especialidades;

    public TipoProfissional(string descricao, int id = default) : base(id)
    {
        Descricao = descricao;
        // _especialidades = especialidades ?? new HashSet<Especialidade>();
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