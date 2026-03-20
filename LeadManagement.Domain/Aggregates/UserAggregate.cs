namespace LeadManagement.Domain.Aggregates
{
    public class UserAggregate
    {
        public string Email { get; private set; } = string.Empty;

        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
