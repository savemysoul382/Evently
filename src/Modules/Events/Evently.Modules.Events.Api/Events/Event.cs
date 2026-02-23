// Evently.Modules.Events.Api

namespace Evently.Modules.Events.Api.Events;

// better create value objects, for example DateRange for 2 dates, bit we focus on architecture here
public sealed class Event
{
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string Location { get; set; }

    public DateTime StartsAtUtc { get; set; }

    public DateTime? EndsAtUtc { get; set; }

    public EventStatus Status { get; set; }
}
