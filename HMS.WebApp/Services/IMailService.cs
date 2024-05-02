namespace HMS.WebApp.Services
{
    public interface IMailService
    {
        void Send(string email, string subject, string body);
    }
}
