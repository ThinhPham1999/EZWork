using EZWork.Core.Entities;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EZWork.Core.Repository
{
   public class SignInRepository: SignInManager<EZAccount, string>
    {
        public SignInRepository(AccountRepository userManager, IAuthenticationManager authenticationManager)
          : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(EZAccount user)
        {
            return user.GenerateUserIdentityAsync((AccountRepository)UserManager);
        }

        public static SignInRepository Create(IdentityFactoryOptions<SignInRepository> options, IOwinContext context)
        {
            return new SignInRepository(context.GetUserManager<AccountRepository>(), context.Authentication);
        }

    }
}
