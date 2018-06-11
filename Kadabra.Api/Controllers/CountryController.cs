using System.Web.Http;
using Kadabra.Model.Country;
using System.Threading.Tasks;
using Kadabra.Model.Country.Services;
using Kadabra.Api.Servicios;
using Kadabra.Data;
using System;

namespace Kadabra.Api.Controllers
{
    [RoutePrefix("Country")]
    public class CountryController : ApiController
    {
        private readonly ICountryServices services;

        public CountryController() : this(new CountryServices(new Repository()))
        {

        }

        public CountryController(ICountryServices services)
        {
            this.services = services;
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAllCountries()
        {
            return Ok<CountryCollectionModel>(await services.GetAllCountries());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<CountryModel> GetCountry(CountryIdModel model)
        {
            return await services.GetCountry(model);
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<IHttpActionResult> AddCountry(CountryAddModel country)
        {
            if (!ModelState.IsValid) return this.InternalServerError();
            try
            {
                await services.Add(country);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> EditCountry(CountryModel country)
        {
            if (!ModelState.IsValid) return InternalServerError();
            try
            {
                await services.Edit(country);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> DeleteCountry(CountryIdModel country)
        {
            if (!ModelState.IsValid) return InternalServerError();
            try
            {
                await services.Remove(country);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}