namespace LeadManagement.Domain.ValueObject
{
    public class ContactInfo
    {
        public string FirstName { get; private set; }
        public string FullName { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public ContactInfo(string firstName, string fullName, string phone, string email)
        {
            FirstName = firstName;
            FullName = fullName;
            Phone = phone;
            Email = email;
        }
    }
}
