// Evently.Modules.Events.Api

using System;
using Evently.Modules.Events.Api.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Api.Events;

public static class CreateEvent
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost(
            pattern: "events",
            handler: async (Request request, EventsDbContext context) =>
            {
                var @event = new Event
                {
                    Id = Guid.NewGuid(),
                    Title = request.Title,
                    Description = request.Description,
                    Location = request.Location,
                    StartsAtUtc = request.StartsAtUtc,
                    EndsAtUtc = request.EndsAtUtc,
                    Status = EventStatus.Draft
                };

                context.Events.Add(entity: @event);
                await context.SaveChangesAsync();

                return Results.Ok(@event.Id);
            })
            .WithTags("Events");
    }

    internal sealed class Request
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public DateTime StartsAtUtc { get; set; }

        public DateTime? EndsAtUtc { get; set; }
    }
}
