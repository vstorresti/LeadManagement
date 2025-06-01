using LeadManagement.Application.DTOs;
using LeadManagement.Application.Mappers;
using LeadManagement.Application.Queries;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Repositories;
using MediatR;

namespace LeadManagement.Application.Handlers
{
    public class GetAcceptedLeadsHandler : IRequestHandler<GetAcceptedLeadsQuery, IEnumerable<LeadDTO>>
    {
        private readonly ILeadRepository _repository;

        public GetAcceptedLeadsHandler(ILeadRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LeadDTO>> Handle(GetAcceptedLeadsQuery request, CancellationToken cancellationToken)
        {
            var leads = await _repository.GetByStatusAsync(EnLeadStatus.Accepted);
            var leadsDTOs = leads.MapToLeadDTO();

            return leadsDTOs;

        }
    }
}
