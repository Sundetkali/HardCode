using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardCode.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public MailJetSettings _mailJetSettings { get; set; }

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }

        public async Task Execute(string email, string subject, string body)
        {
            MailjetClient client = new MailjetClient(Environment.GetEnvironmentVariable("ad08c50c40ac5de6153885d90123f2f7"), Environment.GetEnvironmentVariable("18151187f25d6b004f8414c3eaaa8710"))
            {
                Version = ApiVersion.V3_1,
            };
            MailjetRequest request = new MailjetRequest
            {
                Resource = Send.Resource,
            }
             .Property(Send.Messages, new JArray {
                 new JObject 
                 {
                    {
                        "From",
                        new JObject 
                        {
                            {"Email", "anarbais0608@gmail.com"},
                            {"Name", "Sundetkali"}
                        }
                    }, 
                    {
                        "To",
                        new JArray 
                        {
                            new JObject 
                            {
                                {"Email","anarbais0608@gmail.com"},
                                {"Name","Sundetkali"}
                            }
                        }
                    }, 
                    {"Subject","Greetings from Mailjet."}, 
                    {"TextPart","My first Mailjet email"}, 
                    {"HTMLPart","<h3>Dear passenger 1, welcome to <a href='https://www.mailjet.com/'>Mailjet</a>!</h3><br />May the delivery force be with you!"}, 
                    {"CustomID","AppGettingStartedTest"}
                 }
             });
            MailjetResponse response = await client.PostAsync(request);
        }
    }
}
