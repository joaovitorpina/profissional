using MediatR;
using Profissional.Domain.Exceptions;

namespace Profissional.Domain.SeedWork;

public abstract class Entity
{
    private int? _requestedHashCode;

    public virtual int Id { get; protected set; }

    public List<INotification>? DomainEvents { get; private set; }

    public void AddDomainEvent(INotification eventItem)
    {
        DomainEvents ??= new List<INotification>();
        DomainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(INotification eventItem)
    {
        DomainEvents?.Remove(eventItem);
    }

    public bool IsTransient()
    {
        return Id == default;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Entity item)
            return false;
        if (ReferenceEquals(this, item))
            return true;
        if (GetType() != item.GetType())
            return false;
        if (item.IsTransient() || IsTransient())
            return false;

        return item.Id == Id;
    }

    public override int GetHashCode()
    {
        if (IsTransient()) return base.GetHashCode();

        _requestedHashCode ??= Id.GetHashCode() ^ 31;
        // XOR for random distribution. See:
        // https://docs.microsoft.com/archive/blogs/ericlippert/guidelines-and-rules-for-gethashcode
        return _requestedHashCode.Value;
    }

    public static bool operator ==(Entity? left, Entity? right)
    {
        return left?.Equals(right) ?? Equals(right, null);
    }

    public static bool operator !=(Entity left, Entity right)
    {
        return !(left == right);
    }

    public void InserirId(int id)
    {
        if (Id != default) throw new EntidadePersistidaException();

        Id = id;
    }
}