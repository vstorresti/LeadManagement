namespace LeadManagement.Domain.Events
{
    public abstract class LeadEvent
    {
        public int LeadId { get; set; }
        public DateTime OccurredAt { get; set; } = DateTime.UtcNow;
        public abstract string EventType { get; }
    }
}
