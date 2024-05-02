namespace HMS.WebApp.Services
{
    public class GmailService : IMailService
    {
        private ILogger<GmailService> _logger;
        public GmailService(ILogger<GmailService> logger)
        {
            _logger = logger;

        }

        public void Send(string email, string subject, string body)
        {
            //Gmail mail gönderme

            string log = $"{email} - {subject} - {body} mail gmail servisinden gönderildi.";

            _logger.LogInformation(log);
        }
    }
}
