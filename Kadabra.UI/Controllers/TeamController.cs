using Kadabra.Model.Team;
using Kadabra.Model.Team.Services;
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
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            TeamCollectionModel model = await teamService.GetAll();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddTeam()
        {
            await teamService.Add(new TeamAddModel() { Country="Costa Rica", ImageFlag="", Name= "Costa Rica", TeamKey="CRC" });
            return RedirectToAction("Index");
        }
    }
}