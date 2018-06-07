using System.Web.Http;
using Kadabra.Model.Team;
using System.Threading.Tasks;
using Kadabra.Model.Team.Services;
using Kadabra.Api.Servicios;
using Kadabra.Data;
using Kadabra.Data.Identity;
using System;

namespace Kadabra.Api.Controllers
{
    [RoutePrefix("Team")]
    public class TeamController : ApiController
    {
        private readonly ITeamServices services;

        public TeamController() : this(new TeamServices(new Repository()))
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

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost()]
        [AllowAnonymous]
        public async Task<IHttpActionResult> AddTeam(TeamAddModel team)
        {
            if (ModelState.IsValid)
            {
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
            return this.InternalServerError();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}