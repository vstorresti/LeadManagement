using LeadManagement.Application.Commands;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Events;
using LeadManagement.Domain.Repositories;
using LeadManagement.Domain.ValueObject;
using LeadManagement.Infrastructure.Services.Interfaces;
using MediatR;

namespace LeadManagement.Application.Handlers
{
    public class CreateLeadHandler : IRequestHandler<CreateLeadCommand, int>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IEventStoreService _eventStore;

        public CreateLeadHandler(ILeadRepository leadRepository, IEventStoreService eventStore)
        {
            _leadRepository = leadRepository;
            _eventStore = eventStore;
        }

        public async Task<int> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var contact = new ContactInfo(
                request.ContactFirstName,
                request.ContactFullName,
                request.PhoneNumber,
                request.Email);

            var lead = new Lead(
                contact,
                request.Suburb,
                request.Category,
                request.Description,
                request.Price,
                EnLeadStatus.Created
            );

            await _leadRepository.AddAsync(lead);
            await _eventStore.SaveEventAsync(new LeadCreatedEvent { LeadId = lead.Id, LeadSnapshot = lead });
            return lead.Id;
        }
    }
}
