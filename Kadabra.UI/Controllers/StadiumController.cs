using Kadabra.Model.Country.Services;
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
        private readonly ICountryServices countryService;
        public StadiumController()
        {
            stadiumService = new StadiumServicesClient();
            countryService = new CountryServicesClient();
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
            var model = new StadiumAddModelWithCountries() { Countries = await countryService.GetAllCountries() };
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(StadiumIdModel stadium)
        {
            StadiumModel model = await stadiumService.GetStadium(stadium);
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
            return View("Edit");
        }

        [HttpPost]
        public async Task<ActionResult> AddStadium(StadiumAddModel stadium)
        {
            if (ModelState.IsValid)
            {
                await stadiumService.Add(stadium);
                return RedirectToAction("Index");
            }
            return View("Add");
        }
    }
}