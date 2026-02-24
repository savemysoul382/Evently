// Evently.Modules.Events.Api

namespace Evently.Modules.Events.Domain.Events;

// better create value objects, for example DateRange for 2 dates, bit we focus on architecture here
public sealed class Event : Entity
{
    //EF core
    private Event()
    {
    }

    public Guid Id { get; private set; }

    public string Title { get; private set; }

    public string Description { get; private set; }

    public string Location { get; private set; }

    public DateTime StartsAtUtc { get; private set; }

    public DateTime? EndsAtUtc { get; private set; }

    public EventStatus Status { get; private set; }

    public static Event Create(string title, string description, string location, DateTime startsAtUtc, DateTime? endsAtUtc, EventStatus status)
    {
        var @event = new Event
        {
            Id = Guid.NewGuid(),
            Title = title,
            Description = description,
            Location = location,
            StartsAtUtc = startsAtUtc,
            EndsAtUtc = endsAtUtc,
            Status = status
        };

        @event.RaiseDomainEvent(new EventCreatedDomainEvent(@event.Id));

        return @event;
    }
}
