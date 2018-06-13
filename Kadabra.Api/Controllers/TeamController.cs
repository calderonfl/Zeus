using System.Web.Http;
using Kadabra.Model.Team;
using System.Threading.Tasks;
using Kadabra.Model.Team.Services;
using Kadabra.Api.Servicios;
using Kadabra.Data;
using System;
using Kadabra.Model.Country;

namespace Kadabra.Api.Controllers
{
    [RoutePrefix("Team")]
    public class TeamController : ApiController
    {
        private readonly ITeamServices services;

        public TeamController() : this(new TeamServices(new RepositoryTeam()))
        {

        }

        public TeamController(ITeamServices services)
        {
            this.services = services;
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAll()
        {
            return Ok<TeamCollectionModel>(await services.GetAll());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<TeamModel> Get(TeamIdModel model)
        {
            return await services.Get(model);
        }
        
        [HttpPost()]
        [AllowAnonymous]
        public async Task<IHttpActionResult> AddTeam(TeamAddModel team)
        {
            if (!ModelState.IsValid) return this.InternalServerError();
            try
            {
                await services.Add(team);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> EditTeam(TeamModel team)
        {
            if (!ModelState.IsValid) return InternalServerError();
            try
            {
                await services.Edit(team);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IHttpActionResult> DeleteTeam(TeamIdModel team)
        {
            if (!ModelState.IsValid) return InternalServerError();
            try
            {
                await services.Remove(team);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet()]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAllCountries()
        {
            return Ok<CountryCollectionModel>(await services.GetAllCountries());
        }
    }
}