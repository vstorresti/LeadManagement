using MediatR;

namespace LeadManagement.Application.Commands
{
    public record AcceptLeadCommand(int LeadId) : IRequest<Unit>;

}
