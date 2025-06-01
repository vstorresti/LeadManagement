using LeadManagement.Domain.Enums;
using MediatR;

namespace LeadManagement.Application.Commands
{
    public record CreateLeadCommand(string ContactFirstName, string ContactFullName,
        string PhoneNumber, string Email, string Suburb, string Category, string Description, decimal Price, EnLeadStatus Status = EnLeadStatus.Created) : IRequest<int>;
}
