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
    public class AdministratorsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public AdministratorsController()
        {
            _adminFactory = new AdminFactory();
        }

        [Route("api/Administrators/{admin}")]
        public IEnumerable<AdminModel> UserLogin(AdminModel admin)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetLoginData(admin).ToList().Select(c => _adminFactory.Create(c));
        }

        // GET: api/Administrators       
        public IEnumerable<AdminModel> GetAdministrators()
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllAdmin().ToList().Select(c => _adminFactory.Create(c));
        }

        // GET: api/Administrators/5        
        [Route("api/Administrators/{id}")]
        public IEnumerable<AdminModel> GetAdministrator(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllAdmin(id).ToList().Select(c => _adminFactory.Create(c));
        }

        // PUT: api/Administrators/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdministrator(Administrator administrator)
        {
            int id = administrator.AdminId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != administrator.AdminId)
            {
                return BadRequest();
            }

            db.Entry(administrator).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdministratorExists(id))
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

        // POST: api/Administrators
        [ResponseType(typeof(Administrator))]
        public IHttpActionResult PostAdministrator(Administrator administrator)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Administrators.Add(administrator);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = administrator.AdminId }, administrator);
        }

        // DELETE: api/Administrators/5
        [Route("api/Administrators/{id}")]
        public IHttpActionResult DeleteAdministrator(int id)
        {
            Administrator administrator = db.Administrators.Find(id);
            if (administrator == null)
            {
                return NotFound();
            }

            db.Administrators.Remove(administrator);
            db.SaveChanges();

            return Ok(administrator);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdministratorExists(int id)
        {
            return db.Administrators.Count(e => e.AdminId == id) > 0;
        }
    }
}