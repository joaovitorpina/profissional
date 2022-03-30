using MediatR;
using Profissional.Domain.Aggregates.TipoProfissional;

namespace Profissional.Domain.Events;

public class EspecialidadeRemovidaEvent : INotification
{
    public EspecialidadeRemovidaEvent(Especialidade especialidadeRemovida, TipoProfissional tipoProfissional)
    {
        EspecialidadeRemovida = especialidadeRemovida;
        TipoProfissional = tipoProfissional;
    }

    public Especialidade EspecialidadeRemovida { get; }
    public TipoProfissional TipoProfissional { get; }
}