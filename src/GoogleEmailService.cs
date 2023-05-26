using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using MimeKit;
using System.Net.Mail;
using System.Text;
namespace GoogleEmailService.APP
{
    public class GoogleEmailService : IEmailService, IDisposable
    {
        private readonly string[] Scopes = { GmailService.Scope.GmailSend };
        private readonly string ApplicationName = "";
        private readonly ServiceAccountCredential _credential;

        public GoogleEmailService(string credentialsFilePath, string userToImpersonate)
        {
            using (var stream = new FileStream(credentialsFilePath, FileMode.Open, FileAccess.Read))
            {
                var googleCredential = GoogleCredential.FromStream(stream);
                if (googleCredential.IsCreateScopedRequired)
                {
                    googleCredential = googleCredential.CreateScoped(Scopes);
                }

                _credential = new ServiceAccountCredential(
                    new ServiceAccountCredential.Initializer((googleCredential.UnderlyingCredential as ServiceAccountCredential).Id)
                    {
                        User = userToImpersonate,
                        Key = (googleCredential.UnderlyingCredential as ServiceAccountCredential).Key,
                        Scopes = Scopes
                    });
            }
        }

        public async Task SendEmailAsync(string[] recipients, string subject, string body, IEnumerable<string> attachments = null)
        {
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    foreach (var recipient in recipients)
                    {
                        mailMessage.To.Add(recipient);
                    }

                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    // Set the encoding to ISO-8859-1
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");

                    if (attachments != null)
                    {
                        foreach (var attachment in attachments)
                        {
                            mailMessage.Attachments.Add(new Attachment(attachment));
                        }
                    }

                    var mimeMessage = MimeMessage.CreateFromMailMessage(mailMessage);

                    var message = new Message
                    {
                        Raw = Base64UrlEncode(mimeMessage.ToString())
                    };

                    var gmailService = new GmailService(new BaseClientService.Initializer
                    {
                        HttpClientInitializer = _credential,
                        ApplicationName = ApplicationName
                    });

                    await gmailService.Users.Messages.Send(message, "me").ExecuteAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to send email: {ex.Message}");
            }
        }

        public async Task SendEmailAsync(string recipient, string subject, string body, IEnumerable<string> attachments = null)
        {
            await SendEmailAsync(new[] { recipient }, subject, body, attachments);
        }

        public void Dispose()
        {

        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
    }
}
