using EZWork.Core.Abstract;
using EZWork.Core.DBContext;
using EZWork.Core.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Repository
{
    public class EmailService : IIdentityMessageService
    {
        readonly ConcurrentQueue<SmtpClient> _clients = new ConcurrentQueue<SmtpClient>();
        public async Task SendAsync(IdentityMessage message)
        {
            var client = GetOrCreateSmtpClient();
            try
            {
                MailMessage mailMessage = new MailMessage();

                mailMessage.To.Add(new MailAddress(message.Destination));
                mailMessage.Subject = message.Subject;
                mailMessage.Body = message.Body;

                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.SubjectEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;
                // there can only ever be one-1 concurrent call to SendMailAsync
                await client.SendMailAsync(mailMessage);
            }
            finally
            {
                _clients.Enqueue(client);
            }
            // Plug in your email service here to send an email.
            //   return Task.FromResult(0);
        }
        private SmtpClient GetOrCreateSmtpClient()
        {
            SmtpClient client = null;
            if (_clients.TryDequeue(out client))
            {
                return client;
            }

            client = new SmtpClient();
            return client;
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
    public class AccountRepository : UserManager<EZAccount>
    {      

        public AccountRepository(IUserStore<EZAccount> store, IIdentityMessageService emailService)
            : base(store)
        {
          this.EmailService = emailService;
        }

        public static AccountRepository Create(IdentityFactoryOptions<AccountRepository> options, IOwinContext context)
        {     
            var manager = new AccountRepository(new UserStore<EZAccount>(context.Get<EZWorkDbContext>()),new EmailService());
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<EZAccount>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(30);
            manager.MaxFailedAccessAttemptsBeforeLockout = 2;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<EZAccount>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<EZAccount>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<EZAccount>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
 
}
