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
    public class RoomsController : ApiController
    {
        private BootCampEntities db = new BootCampEntities();

        AdminFactory _adminFactory;
        public RoomsController()
        {
            _adminFactory = new AdminFactory();
        }

        // GET: api/Rooms        
        public IEnumerable<RoomModel> GetRooms()
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllRooms().ToList().Select(c => _adminFactory.Create(c));
        }

        // GET: api/Rooms/5        
        [Route("api/Rooms/{id}")]
        public IEnumerable<RoomModel> GetRoom(int id)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllRooms(id).ToList().Select(c => _adminFactory.Create(c));
        }

        [Route("api/Rooms/{city}")]
        public IEnumerable<RoomModel> GetAllRooms(string HotelName)
        {
            AdminRepository cr = new AdminRepository();
            return cr.GetAllRoomsByHotelName(HotelName).ToList().Select(c => _adminFactory.Create(c));
        }

        // PUT: api/Rooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoom(Room room)
        {
            int id = room.RoomID;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room.RoomID)
            {
                return BadRequest();
            }

            db.Entry(room).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        [ResponseType(typeof(Room))]
        public IHttpActionResult PostRoom(Room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rooms.Add(room);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = room.RoomID }, room);
        }

        // DELETE: api/Rooms/5
        [Route("api/Rooms/{id}")]
        public IHttpActionResult DeleteRoom(int id)
        {
            Room room = db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            db.Rooms.Remove(room);
            db.SaveChanges();

            return Ok(room);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RoomExists(int id)
        {
            return db.Rooms.Count(e => e.RoomID == id) > 0;
        }
    }
}