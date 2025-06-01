namespace LeadManagement.Domain.Events
{
    public class LeadDeclinedEvent : LeadEvent
    {
        public override string EventType => nameof(LeadDeclinedEvent);
    }
}
