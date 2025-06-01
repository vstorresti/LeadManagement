using LeadManagement.Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace LeadManagement.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public Task SendEmailAsync(string to, string subject, string body)
        {
            _logger.LogInformation("Simulando envio de email para {to}", to);
            return Task.CompletedTask;
        }
    }
}
