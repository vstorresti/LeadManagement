using LeadManagement.Domain.Events;

namespace LeadManagement.Infrastructure.Services.Interfaces
{
    public interface IEventStoreService
    {
        Task SaveEventAsync(LeadEvent @event);
    }
}
