namespace LeadManagement.Domain.Events
{
    public class LeadAcceptedEvent : LeadEvent
    {
        public override string EventType => nameof(LeadAcceptedEvent);
    }
}
