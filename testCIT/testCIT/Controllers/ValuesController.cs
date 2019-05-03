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
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<Student> Get()
        {
            return new StudentRepository().ReadList();
        }

        // GET api/values/5
        public Student Get(int id)
        {
            return new StudentRepository().Read(id);
        }

        // POST api/values
        public void Post([FromBody]Student value)
        {
            new StudentRepository().Create(value);
            //new StudentRepository().Update(value);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Student value)
        {
            new StudentRepository().Update(value);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            new StudentRepository().Delete(id);
        }
    }
}
