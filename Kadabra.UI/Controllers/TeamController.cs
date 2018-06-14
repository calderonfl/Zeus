using Kadabra.Model.Country;
using Kadabra.Model.Team;
using Kadabra.Model.Team.Services;
using Kadabra.UI.Clients;
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
            var model = await teamService.GetTeamWithCountries();
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(TeamIdModel team)
        {
            var model = await teamService.GetTeamWithCountries(team);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(TeamIdModel team)
        {
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
            else
            {
                var model = await teamService.GetTeamWithCountries(new TeamIdModel() { Id = team.Id });
                return View("Edit", model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddTeam(TeamAddModel team)
        {
            if (ModelState.IsValid)
            {
                await teamService.Add(team);
                return RedirectToAction("Index");
            }else
            {
                var model = await teamService.GetTeamWithCountries();
                return View("Add", model);
            }
        }
    }
}