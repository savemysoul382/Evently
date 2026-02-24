// Evently.Modules.Events.Domain

namespace Evently.Modules.Events.Domain.Events;

public interface IDomainEvent
{
    Guid Id { get; }

    DateTime OccurredOnUtc { get; }
}
