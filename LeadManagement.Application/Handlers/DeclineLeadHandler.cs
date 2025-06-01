using LeadManagement.Application.Commands;
using LeadManagement.Domain.Enums;
using LeadManagement.Domain.Events;
using LeadManagement.Domain.Repositories;
using LeadManagement.Infrastructure.Services.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LeadManagement.Application.Handlers
{
    public class DeclineLeadHandler : IRequestHandler<DeclineLeadCommand, Unit>
    {
        private readonly ILeadRepository _repository;
        private readonly IEventStoreService _eventStore;
        private readonly ILogger<DeclineLeadHandler> _logger;

        public DeclineLeadHandler(
            ILeadRepository repository,
            IEventStoreService eventStore,
            ILogger<DeclineLeadHandler> logger
        )
        {
            _repository = repository;
            _eventStore = eventStore;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = await _repository.GetByIdAsync(request.LeadId);

            if (lead.Status != EnLeadStatus.Created)
            {
                _logger.LogError("Invalid status - {status}", lead.Status);
                return Unit.Value;
            }

            lead.Decline();

            await _repository.UpdateAsync(lead);
            await _eventStore.SaveEventAsync(new LeadDeclinedEvent { LeadId = lead.Id });

            return Unit.Value;
        }
    }
}
