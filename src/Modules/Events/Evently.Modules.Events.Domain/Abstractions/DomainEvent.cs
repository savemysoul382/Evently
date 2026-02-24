// Evently.Modules.Events.Domain

namespace Evently.Modules.Events.Domain.Events;

public abstract class DomainEvent : IDomainEvent
{
    public Guid Id { get; init; }

    public DateTime OccurredOnUtc { get; init; }

    protected DomainEvent()
    {
        Id = Guid.Empty;
        OccurredOnUtc = DateTime.UtcNow;
    }

    protected DomainEvent(Guid id, DateTime occurredOnUtc)
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
    }
}
