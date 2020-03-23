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
    public class KurssiController : ControllerBase
    {
        // GET: api/Kurssi-TOIMII
        [HttpGet]
        public IEnumerable<Kurssit> Get()
        {
           using (AcademyToolContext db = new AcademyToolContext())
            {
                return db.Kurssit.ToList();
            }
        }

        // GET: api/Kurssi/5
        [HttpGet("{id}", Name = "GetKurssi")]
        public Kurssit Get(int id)
        {
            AcademyToolContext db = new AcademyToolContext();
            Kurssit kurssi = db.Kurssit.Find(id);
            return kurssi;
        }

        // POST: api/Kurssi-TOIMII
        [HttpPost]
        public void Post([FromBody] Kurssit tiedot)
        {
            AcademyToolContext db = new AcademyToolContext();
            int tid = db.Kurssit.Max(p => p.KurssiId) + 1;
            tiedot.KurssiId = tid;
            db.Kurssit.Add(tiedot);
            db.SaveChanges();
        }

        // PUT: api/Kurssi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Kurssit kurssi)
        {
            using (AcademyToolContext db = new AcademyToolContext())
            {
                Kurssit k = db.Kurssit.Find(id);
                k.Nimi = kurssi.Nimi;
                k.MinPaikat = kurssi.MinPaikat;
                k.PaikkojaVapaana = kurssi.PaikkojaVapaana;
                k.OpintoSuunnitelma = kurssi.OpintoSuunnitelma;
                k.Statuksen = kurssi.Statuksen;

                db.SaveChanges();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            
            using ( AcademyToolContext db = new AcademyToolContext())
            {
                Kurssit kurssi = db.Kurssit.Where(k => k.KurssiId == id).Single < Kurssit > ();
                db.Kurssit.Remove(kurssi);
                db.SaveChanges();
            }
        }
    }
}
