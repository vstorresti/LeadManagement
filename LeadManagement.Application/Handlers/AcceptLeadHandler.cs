using LeadManagement.Application.Commands;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Events;
using LeadManagement.Domain.Repositories;
using LeadManagement.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LeadManagement.Application.Handlers
{
    public class AcceptLeadHandler : IRequestHandler<AcceptLeadCommand, Unit>
    {
        private readonly ILeadRepository _leadRepository;
        private readonly IEventStoreService _eventStoreService;
        private readonly IEmailService _emailService;
        private readonly ILogger<AcceptLeadHandler> _logger;

        public AcceptLeadHandler(
            ILeadRepository leadRepository,
            IEventStoreService eventStoreService,
            IEmailService emailService,
            ILogger<AcceptLeadHandler> logger
        )
        {
            _leadRepository = leadRepository;
            _eventStoreService = eventStoreService;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Unit> Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _leadRepository.GetByIdAsync(request.LeadId);

            if (lead.Status != EnLeadStatus.Created)
            {
                _logger.LogError("Invalid status - {status}", lead.Status);
                return Unit.Value;
            }

            lead.Accept();

            await _leadRepository.UpdateAsync(lead);
            await _eventStoreService.SaveEventAsync(new LeadAcceptedEvent { LeadId = request.LeadId });

            await _emailService.SendEmailAsync(lead.Contact.Email, "Subject", "Body");

            return Unit.Value;
        }
    }
}
