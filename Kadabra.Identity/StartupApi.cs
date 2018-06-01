using Owin;
using Kadabra.Data.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

//[assembly: OwinStartup(typeof(Kadabra.Identity.Startup))]
namespace Kadabra.Identity
{
    public class StartupApi
    {
        public static KadabraAuthProvider OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }
        public static void Configuration(IAppBuilder app)
        {
            PublicClientId = "self";
            app.CreatePerOwinContext(KadabraContext.Create);
            app.CreatePerOwinContext<KadabraUserManager>(KadabraUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            app.UseOAuthBearerTokens(new KadabraAuthorizationServerOptions(PublicClientId));
        }
    }
}
