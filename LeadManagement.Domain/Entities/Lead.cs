using LeadManagement.Domain.Core;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.ValueObject;

namespace LeadManagement.Domain.Entities
{
    public class Lead : BaseEntity
    {
        public ContactInfo Contact { get; private set; }
        public string Suburb { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime DateCreated { get; private set; }
        public EnLeadStatus Status { get; private set; }

        public Lead() { }

        public Lead(ContactInfo contact, string suburb, string category, string description, decimal price, EnLeadStatus status)
        {
            Contact = contact;
            Suburb = suburb;
            Category = category;
            Description = description;
            Price = price;
            DateCreated = DateTime.UtcNow;
            Status = status;
        }

        public void Accept()
        {
            if (Price > 500) Price -= Price * 0.10m;
            Status = EnLeadStatus.Accepted;
        }

        public void Decline() => Status = EnLeadStatus.Declined;
    }
}
