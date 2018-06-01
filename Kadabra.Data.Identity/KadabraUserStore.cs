using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Kadabra.Data.Identity
{
    public class KadabraUserStore : UserStore<KadabraUser>
    {
        public KadabraUserStore(IOwinContext context) : base(context.Get<KadabraContext>())
        {
                
        }
    }
}
