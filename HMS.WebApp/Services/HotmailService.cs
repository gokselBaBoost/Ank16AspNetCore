namespace HMS.WebApp.Services
{
    public class HotmailService : IMailService
    {
        private ILogger<HotmailService> _logger;
        public HotmailService(ILogger<HotmailService> logger)
        {
            _logger = logger;

        }

        public void Send(string email, string subject, string body)
        {

            string log = $"{email} - {subject} - {body} mail Hotmail servisinden gönderildi.";

            _logger.LogInformation(log);
        }
    }
}
