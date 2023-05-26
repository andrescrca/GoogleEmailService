using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleEmailService.APP
{
    public interface IEmailService
    {
        Task SendEmailAsync(string[] recipients, string subject, string body, IEnumerable<string> attachments = null);
        Task SendEmailAsync(string recipient, string subject, string body, IEnumerable<string> attachments = null);
    }
}
