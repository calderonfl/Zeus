using System.Web.Http;
using Kadabra.Model.Team;
using System;
using System.Threading.Tasks;
using Kadabra.Api.Services;

namespace Kadabra.Api.Controllers
{
    [RoutePrefix("Team")]
    public class TeamController : ApiController
    {
        private readonly ITeamServices services;

        public TeamController() : this(new TeamServices())
        {

        }

        public TeamController(ITeamServices services)
        {
            this.services = services;
        }
        // GET api/<controller>
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

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
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