using ECommerceAPI.Application.Abstractions.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Infrastructure.Services
{
    public class MailService : IMailService
    {

        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendMailAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMailAsync(new[] { to }, subject, body, isBodyHtml);
        }

        public async Task SendMailAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
            {
                mail.To.Add(to);
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["Mail:Username"], "Bab E-Commerce", Encoding.UTF8);

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
            smtp.Port = int.Parse(_configuration["Mail:Port"]);
            smtp.EnableSsl = true;
            smtp.Host = _configuration["Mail:Host"];

            await smtp.SendMailAsync(mail);

        }

        public async Task SendPasswordResetMailAsync(string to, string userId, string resetToken)
        {

            StringBuilder mail = new();
            mail.AppendLine("Merhaba<br>Yeni şifre talebinde bulunduysanız linke tıklayın.<br><strong><a target=\"_blank\" href=\"");
            ////@ kullanılarak kaçış karakterini kullanmamak mümkün
            //mail.AppendLine(_configuration["AngularClientUrl"]);
            //mail.AppendLine("/update-password/");
            //mail.AppendLine(userId);
            //mail.AppendLine("/");
            //mail.AppendLine(resetToken);
            ////mail.Replace(" ", "");

            string str = _configuration["AngularClientUrl"] + "/update-password/" + userId + "/" + resetToken;
            mail.AppendLine(str);


            mail.AppendLine("\">Şifre sıfırlamak için tıkla</a></strong><br><br><span style=\"font-size:12px;\">" +
                "Not : Eğer böyle bir talepte bulunmadıysanız destek ekibi ile iletişime geçebilirsiniz</span><br><br>Bab ECommerce");

            await SendMailAsync(to, "Şifre yenileme talebi", mail.ToString());

        }
    }
}
