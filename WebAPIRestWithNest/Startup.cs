using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
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
                AllowedAudiences = new List<string>() {"users"},
                IssuerSecurityTokenProviders =
                    new List<IIssuerSecurityTokenProvider>()
                    {
                        new SymmetricKeyIssuerSecurityTokenProvider("AS", SigningKey)
                    }
            };
            app.UseJwtBearerAuthentication(jwtBearerAuthenticationOptions);
                
            // claims transformation
            //app.UseClaimsTransformation(new ClaimsTransformer().Transform);

            app.UseWebApi(WebApiConfig.Register());
        }
    }

    public class AuthorizationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            // inspect sub, action, resource
            Debug.WriteLine(context.Principal.FindFirst("sub").Value);
            Debug.WriteLine(context.Action.First().Value);
            Debug.WriteLine(context.Resource.First().Value);

            return true;
        }
    }

    public class ClaimsTransformer
    {
        public Task<ClaimsPrincipal> Transform(ClaimsPrincipal incomingPrincipal)
        {
            if (!incomingPrincipal.Identity.IsAuthenticated)
            {
                return Task.FromResult(incomingPrincipal);
            }

            // go to datastore and add app specific claims
            incomingPrincipal.Identities.First().AddClaim(
                new Claim("localclaim", "localvalue"));

            return Task.FromResult(incomingPrincipal);
        }
    }
}
