using LeadManager.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LeadManager.Infrastructure.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            //realiza email.
        }
    }
}
