using System.Web.Http;
using Kadabra.Model.Stadium;
using System.Threading.Tasks;
using Kadabra.Model.Stadium.Services;
using Kadabra.Api.Servicios;
using Kadabra.Data;
using System;

namespace Kadabra.Api.Controllers
{
    [RoutePrefix("Stadium")]
    public class StadiumController : ApiController
    {
        private readonly IStadiumServices services;

        public StadiumController() : this(new StadiumServices(new RepositoryStadium()))
        {

        }

        public StadiumController(IStadiumServices services)
        {
            this.services = services;
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAllStadiums()
        {
            return Ok<StadiumCollectionModel>(await services.GetAllStadiums());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<StadiumModel> GetStadium(StadiumIdModel stadium)
        {
            return await services.GetStadium(stadium);
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<IHttpActionResult> AddStadium(StadiumAddModel stadium)
        {
            if (!ModelState.IsValid) return this.InternalServerError();
            try
            {
                await services.Add(stadium);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> EditStadium(StadiumModel stadium)
        {
            if (!ModelState.IsValid) return InternalServerError();
            try
            {
                await services.Edit(stadium);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> DeleteStadium(StadiumIdModel stadium)
        {
            if (!ModelState.IsValid) return InternalServerError();
            try
            {
                await services.Remove(stadium);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetStadiumWithCountries()
        {
            var model = await services.GetStadiumWithCountries();
            if (model != null)
                return Ok<StadiumModelWithCountries>(model);
            else
                return InternalServerError();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetCurrentStadiumWithCountries(StadiumIdModel stadium)
        {
            var model =  await services.GetStadiumWithCountries(stadium);
            if (model != null)
                return Ok<StadiumModelWithCountries>(model);
            else
                return InternalServerError();
        }
    }
}