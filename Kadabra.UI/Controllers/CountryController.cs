using Kadabra.Model.Country;
using Kadabra.Model.Country.Services;
using Kadabra.UI.Clients;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Kadabra.UI.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryServices CountryService;
        public CountryController()
        {
            CountryService = new CountryServicesClient();
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            CountryCollectionModel model = await CountryService.GetAllCountries();
            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Add()
        {
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<ActionResult> Edit(CountryIdModel Country)
        {
            CountryModel model = await CountryService.GetCountry(Country);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(CountryIdModel Country)
        {
            //CountryModel model = await CountryService.Get(Country);
            await CountryService.Remove(Country);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> SaveCountry(CountryModel Country)
        {
            if (ModelState.IsValid)
            {
                await CountryService.Edit(Country);
                return RedirectToAction("Index");
            }
            return View("Edit");
        }

        [HttpPost]
        public async Task<ActionResult> AddCountry(CountryAddModel Country)
        {
            if (ModelState.IsValid)
            {
                await CountryService.Add(Country);
                return RedirectToAction("Index");
            }
            return View("Add");
        }
    }
}