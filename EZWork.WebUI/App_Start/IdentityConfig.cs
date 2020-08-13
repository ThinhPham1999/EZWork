using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using EZWork.WebUI.Models;
using System.Net.Mail;
using System.Collections.Concurrent;
using System.Text;
using EZWork.Core.Entities;
using EZWork.Core.DBContext;

namespace EZWork.WebUI
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

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    //public class EZUserManager : UserManager<EZAccount>
    //{
    //    public EZUserManager(IUserStore<EZAccount> store)
    //        : base(store)
    //    {
    //    }

    //    public static EZUserManager Create(IdentityFactoryOptions<EZUserManager> options, IOwinContext context) 
    //    {
    //        var manager = new EZUserManager(new UserStore<EZAccount>(context.Get<EZWorkDbContext>()));
    //        // Configure validation logic for usernames
    //        manager.UserValidator = new UserValidator<EZAccount>(manager)
    //        {
    //            AllowOnlyAlphanumericUserNames = false,
    //            RequireUniqueEmail = true
    //        };

    //        // Configure validation logic for passwords
    //        manager.PasswordValidator = new PasswordValidator
    //        {
    //            RequiredLength = 6,
    //            RequireNonLetterOrDigit = false,
    //            RequireDigit = false,
    //            RequireLowercase = false,
    //            RequireUppercase = false,
    //        };

    //        // Configure user lockout defaults
    //        manager.UserLockoutEnabledByDefault = true;
    //        manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
    //        manager.MaxFailedAccessAttemptsBeforeLockout = 5;

    //        // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
    //        // You can write your own provider and plug it in here.
    //        manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<EZAccount>
    //        {
    //            MessageFormat = "Your security code is {0}"
    //        });
    //        manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<EZAccount>
    //        {
    //            Subject = "Security Code",
    //            BodyFormat = "Your security code is {0}"
    //        });
    //        manager.EmailService = new EmailService();
    //        manager.SmsService = new SmsService();
    //        var dataProtectionProvider = options.DataProtectionProvider;
    //        if (dataProtectionProvider != null)
    //        {
    //            manager.UserTokenProvider = 
    //                new DataProtectorTokenProvider<EZAccount>(dataProtectionProvider.Create("ASP.NET Identity"));
    //        }
    //        return manager;
    //    }
    //}

    //// Configure the application sign-in manager which is used in this application.
    //public class EZSignInManager : SignInManager<EZAccount, string>
    //{
    //    public EZSignInManager(EZUserManager userManager, IAuthenticationManager authenticationManager)
    //        : base(userManager, authenticationManager)
    //    {
    //    }

    //    public override Task<ClaimsIdentity> CreateUserIdentityAsync(EZAccount user)
    //    {
    //        return user.GenerateUserIdentityAsync((EZUserManager)UserManager);
    //    }

    //    public static EZSignInManager Create(IdentityFactoryOptions<EZSignInManager> options, IOwinContext context)
    //    {
    //        return new EZSignInManager(context.GetUserManager<EZUserManager>(), context.Authentication);
    //    }
    //}
    //public class EZRoleManager : RoleManager<IdentityRole>
    //{
    //    public EZRoleManager(IRoleStore<IdentityRole, string> roleStore)
    //        : base(roleStore)
    //    {
    //    }

    //    public static EZRoleManager Create(IdentityFactoryOptions<EZRoleManager> options, IOwinContext context)
    //    {
    //        return new EZRoleManager(new RoleStore<IdentityRole>(context.Get<EZWorkDbContext>()));
    //    }
    //}
}
