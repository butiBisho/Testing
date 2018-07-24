using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestingAPI.Models;

namespace TestingAPI
{
    public class ClientRepository
    {
        ///////////////////////////////////////////////Client start////////////////////////////////////////////////////
        public IQueryable<Client> GetLoginData(ClientModel client)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Clients.Where(c => c.Email == client.Email && c.Password == client.Password).Select(e => e);
        }

        public IEnumerable<Client> GetAllClients()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Clients;
        }

        public IEnumerable<Client> GetAllClients(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Clients.Where(c => c.ClientId == id).Select(e => e);
        }        
        /////////////////////////////////////////////Client ends////////////////////////////////////////////////////
        ////////////////////////////////////////////Driver starts//////////////////////////////////////////////////
        public IEnumerable<Driver> GetAllDrivers()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Drivers;
        }

        public IEnumerable<Driver> GetAllDrivers(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Drivers.Where(c => c.ClientId == id).Select(e => e);
        }

        public IEnumerable<Driver> GetDriver(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Drivers.Where(c => c.DriverId == id).Select(e => e);
        }
        ////////////////////////////////////////////Driver ends//////////////////////////////////////////////////
        ///////////////////////////////////////////Partner starts////////////////////////////////////////////////
        public IEnumerable<Partner> GetAllPartners()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Partners;
        }

        public IEnumerable<Partner> GetAllPartners(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Partners.Where(c => c.ClientId == id).Select(e => e);
        }

        public IEnumerable<Partner> GetPartner(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Partners.Where(c => c.PartnerId == id).Select(e => e);
        }
        ///////////////////////////////////////Partner ends/////////////////////////////////////////////////////
        //////////////////////////////////////Traveller starts/////////////////////////////////////////////////
        public IEnumerable<Traveller> GetAllTravellers()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Travellers;
        }

        public IEnumerable<Traveller> GetAllTravellers(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Travellers.Where(c => c.ClientId == id).Select(e => e);
        }

        public IEnumerable<Traveller> GetTraveller(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Travellers.Where(c => c.TravellerId == id).Select(e => e);
        }
        //////////////////////////////////Traveller ends/////////////////////////////////////////////
        /////////////////////////////////ClientCar starts//////////////////////////////////////////
        public IEnumerable<Client_Car> GetAllClient_Cars()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Client_Car;
        }

        public IEnumerable<Client_Car> GetAllClient_Cars(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Client_Car.Where(c => c.ClientId == id).Select(e => e);
        }
        ////////////////////////////ClientCar ends///////////////////////////////////////////////
        //////////////////////////ClientFlight starts///////////////////////////////////////////
        public IEnumerable<Client_Flight> GetAllClient_Flights()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Client_Flight;
        }

        public IEnumerable<Client_Flight> GetAllClient_Flights(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Client_Flight.Where(c => c.ClientId == id).Select(e => e);
        }
        ////////////////////////////ClientFlight ends/////////////////////////////////////////////
        ////////////////////////////ClientHotel starts////////////////////////////////////////////
        public IEnumerable<Client_Hotel> GetAllClient_Hotels()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Client_Hotel;
        }

        public IEnumerable<Client_Hotel> GetAllClient_Hotels(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Client_Hotel.Where(c => c.ClientId == id).Select(e => e);
        }
        //////////////////////////////ClientHotel ends///////////////////////////////////////////
        ////////////////////////////CarPayment starts///////////////////////////////////////////////       
        public IEnumerable<CarPayment> GetAllCarPaymentsByClientId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.CarPayments.Where(c => c.ClientId == id).Select(e => e);
        }
        //////////////////////////////CarPayment ends///////////////////////////////////////////////
        ////////////////////////////FlightPayment starts///////////////////////////////////////////////       
        public IEnumerable<FlightPayment> GetAllFlightPaymentsByClientId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.FlightPayments.Where(c => c.ClientId == id).Select(e => e);
        }
        //////////////////////////////FlightCarPayment ends///////////////////////////////////////////////
        ////////////////////////////HotelPayment starts///////////////////////////////////////////////       
        public IEnumerable<HotelPayment> GetAllHotelPaymentsByClientId(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.HotelPayments.Where(c => c.ClientId == id).Select(e => e);
        }
        //////////////////////////////HotelPayment ends///////////////////////////////////////////////
    }
}