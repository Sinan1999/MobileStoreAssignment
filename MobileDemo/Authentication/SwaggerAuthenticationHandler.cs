using Azure.Core;
using Azure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace MobileDemo.Authentication
{
    public class SwaggerAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        UrlEncoder encoder;
        public SwaggerAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
            this.encoder = encoder;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var querystring = Request.QueryString.Value;
            var identity = new ClaimsIdentity("Basic", ClaimTypes.Name, ClaimTypes.Role);

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "email"));
            identity.AddClaim(new Claim(ClaimTypes.Name, "email"));
            identity.AddClaim(new Claim(ClaimTypes.Role, "User"));

            var principal = new ClaimsPrincipal(identity);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                IsPersistent = true,
            };
            //return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(principal,authProperties,"Basic")));
            return Task.FromResult(AuthenticateResult.NoResult());


        }
        protected override Task HandleChallengeAsync(AuthenticationProperties authenticationProperties)
        {
            authenticationProperties.RedirectUri = "/swaggerlogin";
            Response.Redirect(authenticationProperties.RedirectUri);
            return Task.CompletedTask;
        }


    }


    public class BasicAuthenticationOptions : AuthenticationSchemeOptions
    {

    }
}
