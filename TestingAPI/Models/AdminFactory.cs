using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class AdminFactory
    {
        public AdminModel Create(Administrator admin)
        {
            return new AdminModel()
            {
                AdminId = admin.AdminId,
                Title = admin.Title,
                FirstName = admin.FirstName,
                Surname = admin.Surname,
                Email = admin.Email,
                Password = admin.Password,
                Location = admin.Locations.Select(l => Create(l)),
                Extra = admin.Extras.Select(e => Create(e)),
                Airline = admin.Airlines.Select(a => Create(a)),
                Flight = admin.Flights.Select(f => Create(f)),
                Residence = admin.Residences.Select(r => Create(r)),
                Hotel = admin.Hotels.Select(h => Create(h)),
                Room = admin.Rooms.Select(rr => Create(rr)),
                Supplier = admin.Suppliers.Select(s => Create(s)),
                Car = admin.Cars.Select(c => Create(c))
            };
        }

        public LocationModel Create(Location location)
        {
            return new LocationModel()
            {
                LocationId = location.LocationId,
                AirportName = location.AirportName,
                City = location.City,
                Country = location.Country,
                IATA = location.IATA,
                AdminId = (int)location.AdminId
            };
        }

        public ExtraModel Create(Extra extra)
        {
            return new ExtraModel()
            {
                ExtrasId = extra.ExtrasId,
                Name = extra.Name,
                Price = (float)extra.Price,
                Description = extra.Description,
                AdminID = (int)extra.AdminID
            };
        }

        public AirlineModel Create(Airline airline)
        {
            return new AirlineModel()
            {
                AirlineId = airline.AirlineId,
                AirlineName = airline.AirlineName,
                IATA = airline.IATA,
                AdminID = (int)airline.AdminID,
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
                AirL_ID = (int)flight.AirL_ID,
                FlightDate = (DateTime)flight.FlightDate,
                AdminID = (int)flight.AdminID,
                TotalSeats = (int)flight.TotalSeats,
                SeatsLeft = (int)flight.SeatsLeft,
                AirlineName = flight.Airline.AirlineName,
                Client_Flight = flight.Client_Flight.Select(cf => Create(cf)),
                IATA = flight.Airline.IATA
            };
        }

        public ResidenceModel Create(Residence res)
        {
            return new ResidenceModel()
            {
                LocationID = res.LocationID,
                StreetName = res.StreetName,
                Code = res.Code,
                City = res.City,
                Town = res.Town,
                Country = res.Country,
                AdminID = (int)res.AdminID,
                Hotel = res.Hotels.Select(h => Create(h))
            };
        }

        public HotelModel Create(Hotel hotel)
        {
            return new HotelModel()
            {
                HotelID = hotel.HotelID,
                Name = hotel.Name,
                TelNumber = hotel.TelNumber,
                StarRating = (int)hotel.StarRating,
                NumberOfRooms = (int)hotel.NumberOfRooms,
                LocationId = (int)hotel.LocationId,
                AdminID = (int)hotel.AdminID,
                RoomsLeft = (int)hotel.RoomsLeft,
                Destination = hotel.Residence.City,
                Room = hotel.Rooms.Select(r => Create(r)),
                Client_Hotel = hotel.Client_Hotel.Select(ch => Create(ch)),
                Code = hotel.Residence.Code,
                Country = hotel.Residence.Country,
                StreetName = hotel.Residence.StreetName,
                Town = hotel.Residence.Town
            };
        }

        public RoomModel Create(Room room)
        {
            return new RoomModel()
            {
                RoomID = room.RoomID,
                AccommodationType = room.AccommodationType,
                Facility = room.Facility,
                Theme = room.Theme,
                AccessibilityFeatures = room.AccessibilityFeatures,                
                Price = (float)room.Price,
                HotelId = (int)room.HotelId,                
                AdminID = (int)room.AdminID,
                HotelName = room.Hotel.Name,
                RoomNumber = room.RoomNumber
            };
        }

        public SupplierModel Create(Supplier supplier)
        {
            return new SupplierModel()
            {
                SupplierId = supplier.SupplierId,
                Name = supplier.Name,
                AdminID = (int)supplier.AdminID,
                Car = supplier.Cars.Select(c => Create(c))
            };
        }

        public CarModel Create(Car car)
        {
            return new CarModel()
            {
                CarId = car.CarId,
                Name = car.Name,
                Mileage = car.Mileage,
                Price = (float)car.Price,
                SpecialOffer = car.SpecialOffer,
                CarSpecifications = car.CarSpecifications,
                Transmission = car.Transmission,
                SupplierID = (int)car.SupplierID,
                Location = car.Location,
                Date = (DateTime)car.Date,
                AdminID = (int)car.AdminID,
                TotalCars = (int)car.TotalCars,
                CarsLeft = (int)car.CarsLeft,
                Client_Car = car.Client_Car.Select(cc => Create(cc))
            };
        }

        public ClientCarModel Create(Client_Car client_car)
        {
            return new ClientCarModel()
            {
                CC_Id = client_car.CC_Id,
                DateCreated = (DateTime)client_car.DateCreated,
                Status = client_car.Status,
                TotalCost = (float)client_car.TotalCost,
                ClientId = (int)client_car.ClientId,
                CarId = (int)client_car.CarId
            };
        }

        public ClientFlightModel Create(Client_Flight client_flight)
        {
            return new ClientFlightModel()
            {
                CF_Id = client_flight.CF_Id,
                DateCreated = (DateTime)client_flight.DateCreated,
                Status = client_flight.Status,
                ClientId = (int)client_flight.ClientId,
                FlightId = (int)client_flight.FlightId,
                TotalCost = (float)client_flight.TotalCost
            };
        }

        public ClientHotelModel Create(Client_Hotel client_hotel)
        {
            return new ClientHotelModel()
            {
                CH_Id = client_hotel.CH_Id,
                DateCreated = (DateTime)client_hotel.DateCreated,
                Status = client_hotel.Status,
                TotalCost = (float)client_hotel.TotalCost,
                ClientId = (int)client_hotel.ClientId,
                HotelId = (int)client_hotel.HotelId
            };
        }

    }
}