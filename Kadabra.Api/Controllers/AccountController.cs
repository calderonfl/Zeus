using Kadabra.Data.Identity;
using Kadabra.Entities.Account;
using Kadabra.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq;

namespace Kadabra.Api.Controllers
{
    [Authorize]
    
    [RoutePrefix("Kadabra/Account")]
    public class AccountController : ApiController
    {

        public AccountController(): base() { }

        public AccountController(KadabraUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }
        public KadabraUserManager UserManager { get; private set; }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            KadabraUser user = new KadabraUser() { UserName = model.Email, Email = model.Email };
            IdentityResult result = await UserManager.CreateAsync(user, model.Password);
            return GetErrorResult(result);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null) return InternalServerError();
            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
                if (ModelState.IsValid) return BadRequest();
                return BadRequest(ModelState);
            }
            return Ok();
        }
    }
}
