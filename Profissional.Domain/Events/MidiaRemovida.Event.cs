using MediatR;
using Profissional.Domain.Aggregates.Midias;

namespace Profissional.Domain.Events;

public class MidiaRemovidaEvent : INotification
{
    public MidiaRemovidaEvent(MidiaAbstract midiaRemovida)
    {
        MidiaRemovida = midiaRemovida;
    }

    public MidiaAbstract MidiaRemovida { get; }
}