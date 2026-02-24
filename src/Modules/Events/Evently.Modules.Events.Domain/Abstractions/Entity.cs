// Evently.Modules.Events.Domain

namespace Evently.Modules.Events.Domain.Events;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList();

    protected Entity()
    {
    }

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }


    protected void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
