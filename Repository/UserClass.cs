using Common.Contract;
using MailKit.Net.Smtp;
using MimeKit;
using Repository.Interface;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserClass : IUserClass
    {
        ArtomDBEntities artomDBEntities;
        public UserClass()
        {
            artomDBEntities = new ArtomDBEntities();
        }
        public UserResponse InsertUser(UserContract userContract)
        {
            try
            {
                UserDetail details = new UserDetail()
                {
                    Name = userContract.Name,
                    Email = userContract.Email,
                    Message = userContract.Message,
                };
                artomDBEntities.UserDetails.Add(details);
                artomDBEntities.SaveChanges();
                var response = new UserResponse
                {
                    msg = "Data added successfully"
                };
               
                    var message = new MimeMessage();
                    message.From.Add(new MailboxAddress("ReshmaD", "reshmad2310@gmail.com"));
                    message.To.Add(new MailboxAddress("Reshma", "dreshma253@gmail.com"));
                    message.Subject = "Received, Your question for us";
                    message.Body = new TextPart("plain")
                    {
                        //Text = "Hello, we received your question. Will get back to you soon. Thankyou for your approch"
                        Text= userContract.Message
                    };
                    using (var client = new SmtpClient())
                    {
                        client.Connect("smtp.gmail.com", 587, false);
                        client.Authenticate("reshmad2310@gmail.com", "hpxmkpjixnkqccue");
                        client.Send(message);
                        client.Disconnect(true);
                        client.Dispose();
                    };
                
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }    
}
