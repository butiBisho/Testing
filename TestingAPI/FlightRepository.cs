using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI
{
    public class FlightRepository
    {
        public IQueryable<Flight> GetAllFlights()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Flights;
        }
        
        public IQueryable<Flight> GetAllFlights(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Flights.Where(c => c.FlightId == id).Select(e => e);
        }

        public IQueryable<Flight> GetAllFlightsByLocation(string departureCity, string arrivalCity, DateTime date)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Flights.Where(c => c.DepartureLocation == departureCity & c.ArrivalLocation == arrivalCity & c.FlightDate == date).Select(e => e);
        }

        public IQueryable<Airline> GetAllAirlines()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Airlines;
        }

        public IQueryable<Airline> GetAllAirlines(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Airlines.Where(c => c.AirlineId == id).Select(e => e);
        }       

    }
}