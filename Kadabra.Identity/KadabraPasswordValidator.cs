using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kadabra.Identity
{
    internal class KadabraPasswordValidator : PasswordValidator
    {
        internal KadabraPasswordValidator() : base()
        {
                RequiredLength = 6;
                RequireNonLetterOrDigit = true;
                RequireDigit = true;
                RequireLowercase = true;
                RequireUppercase = true;
        }
    }
}
