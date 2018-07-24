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
    public class CarsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public CarsController()
        {
            _adminFactory = new AdminFactory();
        }

        // GET: api/Cars        
        public IEnumerable<CarModel> GetCars()
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllCars().ToList().Select(c => _adminFactory.Create(c));
        }

        // GET: api/Cars/5        
        [Route("api/Cars/{id}")]
        public IEnumerable<CarModel> GetCar(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllCars(id).ToList().Select(c => _adminFactory.Create(c));
        }

        [Route("api/Cars/{location}/{date}")]
        public IEnumerable<CarModel> GetAllCars(string location, DateTime date)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllCarsByLocationDate(location, date).ToList().Select(c => _adminFactory.Create(c));
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(Car car)
        {
            int id = car.CarId;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.CarId)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        public IHttpActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cars.Add(car);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = car.CarId }, car);
        }

        // DELETE: api/Cars/5
        [Route("api/Cars/{id}")]
        public IHttpActionResult DeleteCar(int id)
        {
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Cars.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Cars.Count(e => e.CarId == id) > 0;
        }
    }
}