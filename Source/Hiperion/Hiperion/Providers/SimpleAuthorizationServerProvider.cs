using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Hiperion.Services;
using Hiperion.Services.Interfaces;

namespace Hiperion.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        private IUserServices _userServices;

        public SimpleAuthorizationServerProvider(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {            
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });        
            
            bool isValidUser = _userServices.Login(context.UserName, context.Password);
            
            if (!isValidUser)
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim("sub", context.UserName));
            //identity.AddClaim(new Claim("role", "user"));
            context.Validated(identity);
        }
    }
}