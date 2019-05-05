using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using testCIT.Context;
using testCIT.Entities;

namespace testCIT.Controllers
{
    public class FacultyController : ApiController
    {
        // GET: api/Faculty
        public IEnumerable<Faculty> Get()
        {
            return new FacultyRepository().ReadList();
        }

        // GET: api/Faculty/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Faculty
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Faculty/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Faculty/5
        public void Delete(int id)
        {
        }
    }
}
