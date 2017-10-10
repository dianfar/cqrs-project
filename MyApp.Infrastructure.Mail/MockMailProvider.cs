using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infrastructure.Mail
{
    public class MockMailProvider : IMailProvider
    {
        public Task SendMailAsync(string subject, string content, string senderAddress, string senderName, string recipientAddress)
        {
            return Task.Factory.StartNew(() => { Console.Write("Send email"); });
        }
    }
}
