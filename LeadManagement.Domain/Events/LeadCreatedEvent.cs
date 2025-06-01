using LeadManagement.Domain.Entities;

namespace LeadManagement.Domain.Events
{
    public class LeadCreatedEvent : LeadEvent
    {
        public Lead LeadSnapshot { get; set; }
        public override string EventType => nameof(LeadCreatedEvent);
    }
}
