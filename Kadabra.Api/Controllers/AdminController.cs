using System.Collections.Generic;
using System.Web.Http;

namespace Kadabra.Api.Controllers
{
    public class AdminController : ApiController
    {
        //private readonly IAdminServices services;
        
        //public AdminController(IAdminServices services)
        //{
        //    this.services = services;
        //}

        
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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