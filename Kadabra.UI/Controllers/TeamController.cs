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

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            TeamCollectionModel model = await teamService.GetAll();
            return View(model);
        }
        [HttpGet]
        public async Task<ActionResult> Add()
        {
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<ActionResult> Edit(TeamIdModel team)
        {
            TeamModel model = await teamService.Get(team);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(TeamIdModel team)
        {
            //TeamModel model = await teamService.Get(team);
            await teamService.Remove(team);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> SaveTeam(TeamModel team)
        {
            if (ModelState.IsValid)
            {
                await teamService.Edit(team);
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        [HttpPost]
        public async Task<ActionResult> AddTeam(TeamAddModel team)
        {
            if (ModelState.IsValid)
            {
                await teamService.Add(team);
                return RedirectToAction("Index");
            }
            return View("Add");
        }
    }
}