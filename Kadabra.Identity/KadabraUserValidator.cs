using Kadabra.Data.Identity;
using Microsoft.AspNet.Identity;

namespace Kadabra.Identity
{
    public class KadabraUserValidator : UserValidator<KadabraUser>
    {
        public KadabraUserValidator(KadabraUserManager manager) : base(manager)
        {
            RequireUniqueEmail = true;
            AllowOnlyAlphanumericUserNames = false;
        }
    }
}
