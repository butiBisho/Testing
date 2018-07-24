using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class ClientFactory
    {
        public ClientModel Create(Client client)
        {
            return new ClientModel()
            {
                ClientId = client.ClientId,
                Title = client.Title,
                FirstName = client.FirstName,
                Surname = client.Surname,
                Email = client.Email,
                Password = client.Password,
                Driver = client.Drivers.Select(d => Create(d)),
                Partner = client.Partners.Select(p => Create(p)),
                Traveller = client.Travellers.Select(t => Create(t)),
                Client_Car = client.Client_Car.Select(cc => Create(cc)),
                Client_Flight = client.Client_Flight.Select(cf => Create(cf)),
                Client_Hotel = client.Client_Hotel.Select(ch => Create(ch)),
                CarPayment = client.CarPayments.Select(cp => Create(cp)),
                FlightPayment = client.FlightPayments.Select(fp => Create(fp)),
                HotelPayment = client.HotelPayments.Select(hp => Create(hp))
            };
        }

        public DriverModel Create(Driver driver)
        {
            return new DriverModel()
            {
                DriverId = driver.DriverId,
                FirstName = driver.FirstName,
                Surname = driver.Surname,
                Email = driver.Email,
                Phone = driver.Phone,
                Address = driver.Address,
                City = driver.City,
                PostCode = driver.PostCode,
                Country = driver.Country,
                FlightNumber = driver.FlightNumber,
                Age = (int)driver.Age,
                ClientId = (int)driver.ClientId
            };
        }

        public PartnerModel Create(Partner partner)
        {
            return new PartnerModel()
            {
                PartnerId = partner.PartnerId,
                FirstName = partner.FirstName,
                LastName = partner.LastName,
                ClientId = (int)partner.ClientId
            };
        }

        public TravellerModel Create(Traveller traveller)
        {
            return new TravellerModel()
            {
                TravellerId = traveller.TravellerId,
                Title = traveller.Title,
                FirstName = traveller.FirstName,
                Surname = traveller.Surname,
                Email = traveller.Email,
                MobileNumber = traveller.MobileNumber,
                Day = traveller.Day,
                Month = traveller.Month,
                Year = traveller.Year,
                ClientId = (int)traveller.ClientId
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
                CarId = (int)client_car.CarId,
                CarPayment = client_car.CarPayments.Select(cp => Create(cp)),
                Name = client_car.Car.Name
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
                TotalCost = (float)client_flight.TotalCost,
                FlightPayment = client_flight.FlightPayments.Select(fp => Create(fp)),
                ArrivalLocation = client_flight.Flight.ArrivalLocation,
                DepartureLocation = client_flight.Flight.DepartureLocation,
                ArrivalTime = client_flight.Flight.ArrivalTime,
                DepartureTime = client_flight.Flight.DepartureTime
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
                HotelId = (int)client_hotel.HotelId,
                HotelPayment = client_hotel.HotelPayments.Select(hp => Create(hp)),
                Name = client_hotel.Hotel.Name
            };
        }

        public CarPaymentModel Create(CarPayment carPayment)
        {
            return new CarPaymentModel()
            {
                PaymentId = carPayment.PaymentId,
                CardNumber = carPayment.CardNumber,
                NameOnCard = carPayment.NameOnCard,
                Month = (int)carPayment.Month,
                Year = (int)carPayment.Year,
                CVV = carPayment.CVV,
                AddressLine1 = carPayment.AddressLine1,
                AddressLine2 = carPayment.AddressLine2,
                PostalCode = carPayment.PostalCode,
                City = carPayment.City,
                Country = carPayment.Country,
                ContactNumber = carPayment.ContactNumber,
                ClientId = (int)carPayment.ClientId,
                CC_Id = (int)carPayment.CC_Id
            };
        }

        public FlightPaymentModel Create(FlightPayment flightPayment)
        {
            return new FlightPaymentModel()
            {
                FlightPaymentId = flightPayment.FlightPaymentId,
                CardNumber = flightPayment.CardNumber,
                NameOnCard = flightPayment.NameOnCard,
                Month = (int)flightPayment.Month,
                Year = (int)flightPayment.Year,
                CVV = flightPayment.CVV,
                AddressLine1 = flightPayment.AddressLine1,
                AddressLine2 = flightPayment.AddressLine2,
                PostalCode = flightPayment.PostalCode,
                City = flightPayment.City,
                Country = flightPayment.Country,
                ContactNumber = flightPayment.ContactNumber,
                ClientId = (int)flightPayment.ClientId,
                CF_Id = (int)flightPayment.CF_Id
            };
        }

        public HotelPaymentModel Create(HotelPayment hotelPayment)
        {
            return new HotelPaymentModel()
            {
                HotelPaymentId = hotelPayment.HotelPaymentId,
                CardNumber = hotelPayment.CardNumber,
                NameOnCard = hotelPayment.NameOnCard,
                Month = (int)hotelPayment.Month,
                Year = (int)hotelPayment.Year,
                CVV = hotelPayment.CVV,
                AddressLine1 = hotelPayment.AddressLine1,
                AddressLine2 = hotelPayment.AddressLine2,
                PostalCode = hotelPayment.PostalCode,
                City = hotelPayment.City,
                Country = hotelPayment.Country,
                ContactNumber = hotelPayment.ContactNumber,
                ClientId = (int)hotelPayment.ClientId,
                CH_Id = (int)hotelPayment.CH_Id
            };
        }

    }
}