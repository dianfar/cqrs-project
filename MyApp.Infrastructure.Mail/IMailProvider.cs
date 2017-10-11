using System.Threading.Tasks;

namespace MyApp.Infrastructure.Mail
{
    public interface IMailProvider
    {
        Task SendMailAsync(string subject, string content, string senderAddress, string senderName, string recipientAddress);
    }
}
