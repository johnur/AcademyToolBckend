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
        public Firma Get(int id)
        {
            AcademyToolContext db = new AcademyToolContext();
            Firma firma = db.Firma.Find(id);
            return firma;
        }

        // POST: api/Firma
        [HttpPost]
        public void Post([FromBody] Firma tiedot)
        {
            AcademyToolContext db = new AcademyToolContext();
            int fid = db.Firma.Max(f => f.FirmaId) + 1;
            tiedot.FirmaId = fid;
            db.Firma.Add(tiedot);
            db.SaveChanges();
        }

        // PUT: api/Firma/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Firma firma)
        {
            using (AcademyToolContext db = new AcademyToolContext())
            {
                Firma f = db.Firma.Find(id);
                f.Ostaja = firma.Ostaja;
                f.OstetutPaikat = firma.OstetutPaikat;
                f.Sitoutuminen = firma.Sitoutuminen;
                f.YhtHenkilö = firma.YhtHenkilö;

                db.SaveChanges();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (AcademyToolContext db = new AcademyToolContext())
            {
                Firma firma = db.Firma.Where(f => f.FirmaId == id).Single<Firma>();
                db.Firma.Remove(firma);
                db.SaveChanges();
            }
        }
    }
}
