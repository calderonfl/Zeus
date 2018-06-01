using Kadabra.Data.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Kadabra.Identity
{
    public class KadabraUserManager : UserManager<KadabraUser>
    {
        public KadabraUserManager(IUserStore<KadabraUser> store)
            : base(store)
        {
        }

        public static KadabraUserManager Create(IdentityFactoryOptions<KadabraUserManager> options, IOwinContext context)
        {
            var manager = new KadabraUserManager(new KadabraUserStore(context));
            manager.UserValidator = new KadabraUserValidator(manager);
            manager.PasswordValidator = new KadabraPasswordValidator();
            if (options != null && options.DataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<KadabraUser>(options.DataProtectionProvider.Create("Kadabra Identity User"));
            }
            return manager;
        }
    }
}
