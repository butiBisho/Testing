using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class ModelFactory
    {        
        public AirlineModel Create(Airline airline)
        {
            return new AirlineModel()
            {
                AirlineId = airline.AirlineId,
                AirlineName = airline.AirlineName,
                IATA = airline.IATA,
                Flight = airline.Flights.Select(f => Create(f))
            };
        }

        public FlightModel Create(Flight flight)
        {
            return new FlightModel()
            {
                FlightId = flight.FlightId,
                DepartureTime = flight.DepartureTime,
                ArrivalTime = flight.ArrivalTime,
                DepartureLocation = flight.DepartureLocation,
                ArrivalLocation = flight.ArrivalLocation,
                Stops = flight.Stops,
                Price = (float)flight.Price,
                FlightDate = (DateTime)flight.FlightDate,
                AirL_ID = (int)flight.AirL_ID,
                AirlineName = flight.Airline.AirlineName
            };
        }

    }
}