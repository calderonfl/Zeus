using Kadabra.Api.Services;
using Kadabra.Model.Team;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kadabra.UI.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamServices teamService;
        public TeamController()
        {
            teamService = new TeamServicesClient();
        }

        // GET: Team
        public async Task<ActionResult> Index()
        {
            TeamCollectionModel model = await teamService.GetAll();
            return View(model);
        }
    }
}