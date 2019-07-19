using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DUTAdmissionSystem.Areas.StudentArea.Controllers
{
    public class FamilyMemberController : ApiController
    {
        // GET: api/FamilyMember
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FamilyMember/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FamilyMember
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/FamilyMember/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/FamilyMember/5
        public void Delete(int id)
        {
        }
    }
}
