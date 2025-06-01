using LeadManagement.Application.DTOs;
using LeadManagement.Application.Mappers;
using LeadManagement.Application.Queries;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Repositories;
using MediatR;

namespace LeadManagement.Application.Handlers
{
    public class GetInvitedLeadsHandler : IRequestHandler<GetInvitedLeadsQuery, IEnumerable<LeadDTO>>
    {
        private readonly ILeadRepository _repository;

        public GetInvitedLeadsHandler(ILeadRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeadDTO>> Handle(GetInvitedLeadsQuery request, CancellationToken cancellationToken)
        {
            var leads = await _repository.GetByStatusAsync(EnLeadStatus.Created);
            var leadsDTOs = leads.MapToLeadDTO();

            return leadsDTOs;
        }
    }

}
