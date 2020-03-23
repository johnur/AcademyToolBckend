using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tool.Models;

namespace tool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        // GET: api/Firma
        [HttpGet]
        public IEnumerable<Firma> Get()
        {
            using (AcademyToolContext db = new AcademyToolContext())
            {
                return db.Firma.ToList();
                //git kokeilu
            }
        }

        // GET: api/Firma/5
        [HttpGet("{id}", Name = "GetFirma")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Firma
        [HttpPost]
        public void Post([FromBody] Firma value)
        {
        }

        // PUT: api/Firma/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
