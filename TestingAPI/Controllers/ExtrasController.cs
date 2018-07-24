using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TestingAPI;
using TestingAPI.Models;

namespace TestingAPI.Controllers
{
    public class ExtrasController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public ExtrasController()
        {
            _adminFactory = new AdminFactory();
        }

        // GET: api/Extras        
        public IEnumerable<ExtraModel> GetExtras()
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllExtras().ToList().Select(c => _adminFactory.Create(c));
        }

        // GET: api/Extras/5        
        [Route("api/Extras/{id}")]
        public IEnumerable<ExtraModel> GetExtra(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllExtras(id).ToList().Select(c => _adminFactory.Create(c));
        }

        // PUT: api/Extras/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutExtra(Extra extra)
        {
            int id = extra.ExtrasId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != extra.ExtrasId)
            {
                return BadRequest();
            }

            db.Entry(extra).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Extras
        [ResponseType(typeof(Extra))]
        public IHttpActionResult PostExtra(Extra extra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Extras.Add(extra);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = extra.ExtrasId }, extra);
        }

        // DELETE: api/Extras/5
        [Route("api/Extras/{id}")]
        public IHttpActionResult DeleteExtra(int id)
        {
            Extra extra = db.Extras.Find(id);
            if (extra == null)
            {
                return NotFound();
            }

            db.Extras.Remove(extra);
            db.SaveChanges();

            return Ok(extra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ExtraExists(int id)
        {
            return db.Extras.Count(e => e.ExtrasId == id) > 0;
        }
    }
}