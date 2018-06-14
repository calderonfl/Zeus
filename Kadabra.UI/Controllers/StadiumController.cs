using Kadabra.Model.Stadium;
using Kadabra.Model.Stadium.Services;
using Kadabra.UI.Clients;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kadabra.UI.Controllers
{
    public class StadiumController : Controller
    {
        private readonly IStadiumServices stadiumService;
        public StadiumController()
        {
            stadiumService = new StadiumServicesClient();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            StadiumCollectionModel model = await stadiumService.GetAllStadiums();
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            var stadium = await stadiumService.GetStadiumWithCountries();
            return View(stadium);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(StadiumIdModel stadium)
        {
            StadiumModelWithCountries model = await stadiumService.GetStadiumWithCountries(stadium);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(StadiumIdModel stadium)
        {
            await stadiumService.Remove(stadium);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> SaveStadium(StadiumModel stadium)
        {
            if (ModelState.IsValid)
            {
                await stadiumService.Edit(stadium);
                return RedirectToAction("Index");
            }
            else
            {
                StadiumModelWithCountries model = await stadiumService.GetStadiumWithCountries(new StadiumIdModel() { Id = stadium.Id});
                return View("Edit", model);
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddStadium(StadiumAddModel stadium)
        {
            if (ModelState.IsValid)
            {
                await stadiumService.Add(stadium);
                return RedirectToAction("Index");
            }
            else
            {
                StadiumModelWithCountries model = await stadiumService.GetStadiumWithCountries();               
                return View("Add", model);
            }
        }
    }
}