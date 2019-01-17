using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using ipsmedserviceapp.DATA;

namespace ipsmedserviceapp.Services
{
    public class EmailService
    {
        public async Task SendActivationEmailAsync(ApplicationUser user, string token)
        {
            var subject = "Підтвердження email";
            var link = UrlHelper.GetUrl("email", $"token={token}&userId={user.Id}");

            var sb = new StringBuilder();
            sb.Append("<h3>UNI.ORG.UA</h3>");
            sb.Append("Для активації облікового запису, будь ласка, перейдіть за посиланням нижче.");
            sb.AppendFormat("<br/><a href = '{0}'>Натисніть тут для активації вашого облікового запису</a>", link);
            sb.Append("<br /><br />Дякуємо!");

            await SendMessageAsync(user.Email, subject, sb.ToString());
        }

        private async Task SendMessageAsync(string email, string subject, string body)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("UNI.ORG.UA (no reply)", "no_reply@uni.org.ua"));
            emailMessage.To.Add(new MailboxAddress(email));
            //emailMessage.To.Add(new MailboxAddress(FirstName+" "+LastName, Email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = body };

            using (var client = new SmtpClient())
            {
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                await client.ConnectAsync("mail.adm.tools", 465, SecureSocketOptions.SslOnConnect);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                await client.AuthenticateAsync("no_reply@uni.org.ua", "CD0mB7Rs6ms7");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }
}