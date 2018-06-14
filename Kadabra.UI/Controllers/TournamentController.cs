using Kadabra.Model.Tournament;
using Kadabra.UI.Clients;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kadabra.UI.Controllers
{
    public class TournamentController : Controller
    {
        private readonly ITournamentServices services;
        public TournamentController() : this(new TournamentServicesClient())
        {
        }
        public TournamentController(ITournamentServices services)
        {
            this.services = services;
        }
        public async Task<ActionResult> Index()
        {
            var model = await services.GetAllTournaments();
            return View(model);
        }
    }
}