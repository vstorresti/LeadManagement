using LeadManagement.Application.DTOs;
using MediatR;

namespace LeadManagement.Application.Queries
{
    public class GetAcceptedLeadsQuery : IRequest<IEnumerable<LeadDTO>> { }

}
