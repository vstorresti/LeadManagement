using LeadManagement.Domain.Entities;

namespace LeadManagement.Domain.Events
{
    public class LeadCreatedEvent : LeadEvent
    {
        public override string EventType => nameof(LeadCreatedEvent);
    }
}
