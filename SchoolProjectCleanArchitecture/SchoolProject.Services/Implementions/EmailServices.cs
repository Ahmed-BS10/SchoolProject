using Microsoft.AspNetCore.Http;
using SchoolProject.Data.Helper;
using SchoolProject.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace SchoolProject.Services.Implementions
{
    public class EmailServices : IEmailServices
    {
        #region Fields
        private readonly MailSetting _mailSetting;
        #endregion

        #region Constrcutor(s)

        public EmailServices(MailSetting mailSetting)
        {
            _mailSetting=mailSetting;
        }
        #endregion

        public async Task<string> SendEmailAsync(string maliTo, string subject, string body, IList<IFormFile> formFiles = null)
        {
            // Sender And Object 
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSetting.Email),
                Subject = subject
            };

            // Send to how ? 
            email.To.Add(MailboxAddress.Parse(maliTo));

            var builder = new BodyBuilder();
            if (formFiles != null)
            {
                byte[] filebytes;
                foreach (var file in formFiles)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        filebytes = ms.ToArray();

                        builder.Attachments.Add(file.Name, filebytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Email));

            using (var smtp = new SmtpClient())
            {
                try
                {
                   await smtp.ConnectAsync(_mailSetting.Host, _mailSetting.Port, false);
                   await smtp.AuthenticateAsync(_mailSetting.Email, _mailSetting.Password);

                   await smtp.SendAsync(email);
                    return "Success";
                }
                catch (SmtpCommandException ex)
                {
                    // Handle SMTP command errors (e.g., authentication issues, etc.)
                    Console.WriteLine($"Error sending email: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    // Handle general errors
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                    throw;
                }
                finally
                {
                   await smtp.DisconnectAsync(true);  // Ensures proper disconnect even in case of error
                }
            }

        }
        public async Task<string> SendEmailAsync(string email, string _message, string? reason)
        {

            try
            {
                //sending the Message of passwordResetLink
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_mailSetting.Host, _mailSetting.Port, true);
                    client.Authenticate(_mailSetting.Email, _mailSetting.Password);
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{_message}",
                        TextBody = "welcome",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Ahmed Cleen", _mailSetting.Email));
                    message.To.Add(new MailboxAddress("testing", email));
                    message.Subject = reason == null ? "No Submitted" : reason;
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                //end of sending email
                return "Success";
            }
            catch (Exception ex)
            {
                

                return "Failed";
            }
        }

    }

}
