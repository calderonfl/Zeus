using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadabra.Identity
{
    public class KadabraAuthorizationServerOptions : OAuthAuthorizationServerOptions
    {
        public KadabraAuthorizationServerOptions(string PublicClientId) : base()
        {
            TokenEndpointPath = new PathString("/Token");
            Provider = new KadabraAuthProvider(PublicClientId);
            AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin");
            AccessTokenExpireTimeSpan = TimeSpan.FromDays(14);
            AllowInsecureHttp = true;
        }
    }
}
