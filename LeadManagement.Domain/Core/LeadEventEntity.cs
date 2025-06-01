namespace LeadManagement.Domain.Core
{
    public class LeadEventEntity
    {
        public int Id { get; set; }
        public int LeadId { get; set; }
        public string EventType { get; set; }
        public string EventData { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
