// Evently.Modules.Events.Domain

using Evently.Modules.Events.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Events;

public sealed class EventCreatedDomainEvent(Guid eventId) : DomainEvent
{
    public Guid EventId { get; } = eventId;
}
