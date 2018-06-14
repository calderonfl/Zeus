using Kadabra.Api.Services;
using Kadabra.Data;
using Kadabra.Model.Tournament;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Kadabra.Api.Controllers
{
    public class TournamentController : ApiController
    {
        private readonly ITournamentServices services;

        public TournamentController() : this(new TournamentServices(new RepositoryTournament()))
        {

        }

        public TournamentController(ITournamentServices services)
        {
            this.services = services;
        }

        [HttpGet()]
        [AllowAnonymous]
        public async Task<IHttpActionResult> GetAllTournaments()
        {
            return Ok<TournamentCollectionModel>(await services.GetAllTournaments());
        }

    }
}