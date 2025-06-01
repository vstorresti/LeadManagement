using LeadManagement.Domain.Core;
using LeadManagement.Domain.Events;
using LeadManagement.Infrastructure.Repositories.Contexts;
using LeadManagement.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LeadManagement.Infrastructure.Services
{
    public class EventStoreService : IEventStoreService
    {
        private readonly LeadDbContext _context;

        public EventStoreService(LeadDbContext context) => _context = context;

        public async Task SaveEventAsync(LeadEvent @event)
        {
            var eventData = JsonSerializer.Serialize(@event);
            var leadEvent = new LeadEventEntity
            {
                LeadId = @event.LeadId,
                EventType = @event.EventType,
                EventData = eventData,
                CreatedAt = @event.OccurredAt
            };

            _context.LeadEvents.Add(leadEvent);
            await _context.SaveChangesAsync();
        }
    }
}
