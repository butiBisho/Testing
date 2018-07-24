using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using TestingAPI.Models;

namespace TestingAPI
{
    public class AdminRepository
    {
        ///////////////////////////////////////////////ADMINISTRATOR STARTS//////////////////////////////////////////////////
        public IQueryable<Administrator> GetLoginData(AdminModel admin)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Administrators.Where(c => c.Email == admin.Email && c.Password == admin.Password).Select(e => e);
        }

        public IEnumerable<Administrator> GetAllAdmin()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Administrators;
        }

        public IEnumerable<Administrator> GetAllAdmin(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Administrators.Where(c => c.AdminId == id).Select(e => e);
        }

        [ResponseType(typeof(Administrator))]
        [HttpPut]
        public HttpResponseMessage UpdateAdmin(Administrator admin)
        {
            BootCampEntities db = new BootCampEntities();
            HttpRequestMessage Request = new HttpRequestMessage();
            int result = 0;
            try
            {
                db.Administrators.Attach(admin);
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        /////////////////////////////////////////////ADMINISTRATOR ENDS///////////////////////////////////////////////////        
        ///////////////////////////////////////////////LOCATION STARTS////////////////////////////////////////////////////
        public IEnumerable<Location> GetAllLocations()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Locations;
        }

        public IEnumerable<Location> GetAllLocations(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Locations.Where(c => c.LocationId == id).Select(e => e);
        }

        public IEnumerable<Location> GetLocationsByAdminId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Locations.Where(c => c.AdminId == id).Select(e => e);
        }
        /////////////////////////////////////////////LOCATION ENDS//////////////////////////////////////////////////////// 
        /////////////////////////////////////////////EXTRAS STARTS////////////////////////////////////////////////////////
        public IEnumerable<Extra> GetAllExtras()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Extras;
        }

        public IEnumerable<Extra> GetAllExtras(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Extras.Where(c => c.ExtrasId == id).Select(e => e);
        }

        public IEnumerable<Extra> GetExtrasByAdminId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Extras.Where(c => c.AdminID == id).Select(e => e);
        }
        /////////////////////////////////////////////EXTRAS ENDS//////////////////////////////////////////////////////////
        /////////////////////////////////////////////AIRLINE STARTS////////////////////////////////////////////////////////
        public IEnumerable<Airline> GetAllAirlines()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Airlines;
        }

        public IEnumerable<Airline> GetAllAirlines(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Airlines.Where(c => c.AirlineId == id).Select(e => e);
        }

        public IEnumerable<Airline> GetAirlinesByAdminId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Airlines.Where(c => c.AdminID == id).Select(e => e);
        }

        public IEnumerable<Airline> GetIATA(string airline, int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Airlines.Where(c => c.AirlineName == airline & c.AdminID == id).Select(e => e);
        }
        /////////////////////////////////////////////AIRLINE ENDS////////////////////////////////////////////////////////
        /////////////////////////////////////////////FLIGHT STARTS////////////////////////////////////////////////////////
        public IEnumerable<Flight> GetAllFlights()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Flights;
        }

        public IEnumerable<Flight> GetAllFlights(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Flights.Where(c => c.FlightId == id).Select(e => e);
        }

        public IEnumerable<Flight> GetFlightsByAdminId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Flights.Where(c => c.AdminID == id).Select(e => e);
        }

        public IEnumerable<Flight> GetAllFlightsByLocation(string departureCity, string arrivalCity, DateTime date)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Flights.Where(c => c.DepartureLocation == departureCity & c.ArrivalLocation == arrivalCity & c.FlightDate == date).Select(e => e);
        }
        /////////////////////////////////////////////FLIGHT ENDS////////////////////////////////////////////////////
        /////////////////////////////////////////////Residence STARTS///////////////////////////////////////////////
        public IEnumerable<Residence> GetAllResidences()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Residences;
        }

        public IEnumerable<Residence> GetAllResidences(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Residences.Where(c => c.LocationID == id).Select(e => e);
        }

        public IEnumerable<Residence> GetResidencesByAdminId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Residences.Where(c => c.AdminID == id).Select(e => e);
        }
        /////////////////////////////////////////////Residence ENDS/////////////////////////////////////////////////
        /////////////////////////////////////////////HOTEL STARTS///////////////////////////////////////////////////
        public IEnumerable<Hotel> GetAllHotels()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Hotels;
        }

        public IEnumerable<Hotel> GetAllHotels(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Hotels.Where(c => c.HotelID == id).Select(e => e);
        }

        public IEnumerable<Hotel> GetHotelsByAdminId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Hotels.Where(c => c.AdminID == id).Select(e => e);
        }

        public IEnumerable<Hotel> GetAllHotelsByCity(string city)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Hotels.Where(c => c.Residence.City == city).Select(e => e);
        }
        /////////////////////////////////////////////HOTEL ENDS/////////////////////////////////////////////////////
        /////////////////////////////////////////////Room STARTS////////////////////////////////////////////////////
        public IEnumerable<Room> GetAllRooms()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Rooms;
        }

        public IEnumerable<Room> GetAllRooms(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Rooms.Where(c => c.RoomID == id).Select(e => e);
        }

        public IEnumerable<Room> GetRoomsByAdminId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Rooms.Where(c => c.AdminID == id).Select(e => e);
        }

        public IEnumerable<Room> GetAllRoomsByHotelName(string HotelName)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Rooms.Where(c => c.Hotel.Name == HotelName).Select(e => e);
        }
        /////////////////////////////////////////////Room ENDS//////////////////////////////////////////////////////
        /////////////////////////////////////////////Supplier STARTS////////////////////////////////////////////////
        public IEnumerable<Supplier> GetAllSuppliers()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Suppliers;
        }

        public IEnumerable<Supplier> GetAllSuppliers(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Suppliers.Where(c => c.SupplierId == id).Select(e => e);
        }

        public IEnumerable<Supplier> GetSupplierByAdminId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Suppliers.Where(c => c.AdminID == id).Select(e => e);
        }
        /////////////////////////////////////////////Supplier ENDS//////////////////////////////////////////////////
        /////////////////////////////////////////////CAR STARTS/////////////////////////////////////////////////////
        public IEnumerable<Car> GetAllCars()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Cars;
        }

        public IEnumerable<Car> GetAllCars(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Cars.Where(c => c.CarId == id).Select(e => e);
        }

        public IEnumerable<Car> GetCarsByAdminId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Cars.Where(c => c.AdminID == id).Select(e => e);
        }

        public IEnumerable<Car> GetAllCarsByLocationDate(string location, DateTime date)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Cars.Where(c => c.Location == location && c.Date == date).Select(e => e);
        }
        /////////////////////////////////////////////CAR ENDS///////////////////////////////////////////////////////
    }
}