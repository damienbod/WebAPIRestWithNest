using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System.IdentityModel.Tokens;
using Thinktecture.IdentityModel;
using Thinktecture.IdentityModel.Tokens;
using System.Diagnostics;
using System.Security.Claims;
using System.Linq;

[assembly: OwinStartup(typeof(WebAPIRestWithNest.Startup))]

namespace WebAPIRestWithNest
{
    public class Startup
    {
        public const string SigningKey = "1fTiS2clmPTUlNcpwYzd5i4AEFJ2DEsd8TcUsllmaKQ=";

        public void Configuration(IAppBuilder app)
        {
            // authorization manager
            ClaimsAuthorization.CustomAuthorizationManager = new AuthorizationManager();

            // no mapping of incoming claims to Microsoft types
            JwtSecurityTokenHandler.InboundClaimTypeMap = ClaimMappings.None;

            // validate JWT tokens from AuthorizationServer
            var jwtBearerAuthenticationOptions = new JwtBearerAuthenticationOptions
            {
                AllowedAudiences = new List<string>() {"users", "damienbod"},
                IssuerSecurityTokenProviders =
                    new List<IIssuerSecurityTokenProvider>()
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider("AS", SigningKey)
                    },
                 Provider = new QueryStringOAuthBearerProvider("token")
            };
            app.UseJwtBearerAuthentication(jwtBearerAuthenticationOptions);
                
            app.UseWebApi(WebApiConfig.Register());
        }
    }

    /// <summary>
    /// This class is required if standard header bearer authentifaction cannot be used. This helper method helps get the resource from a different location.
    /// </summary>
    public class QueryStringOAuthBearerProvider : OAuthBearerAuthenticationProvider
    {
        readonly string _name;

        public QueryStringOAuthBearerProvider(string name)
        {
            _name = name;
        }

        public override Task RequestToken(OAuthRequestTokenContext context)
        {
            var value = context.Request.Query.Get(_name);

            if (!string.IsNullOrEmpty(value))
            {
                context.Token = value;
            }

            return Task.FromResult<object>(null);
        }
    }
    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            // inspect sub, action, resource
            //Debug.WriteLine(context.Principal.FindFirst("sub").Value);
            //Debug.WriteLine(context.Action.First().Value);
            //Debug.WriteLine(context.Resource.First().Value);

            return true;
        }
    }
}
