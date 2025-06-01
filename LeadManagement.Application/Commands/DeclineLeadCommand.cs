using MediatR;

namespace LeadManagement.Application.Commands
{
    public record DeclineLeadCommand(int LeadId) : IRequest<Unit>;

}
