using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI
{
    public class HotelRepository
    {
        public IQueryable<Hotel> GetAllHotels()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Hotels;
        }

        public IQueryable<Hotel> GetAllHotelsByCity(string City)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Hotels.Where(c => c.Residence.City == City).Select(e => e);
        }

        public IQueryable<Room> GetAllRooms()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Rooms;
        }

        public IQueryable<Room> GetAllRoomsByHotelName(string HotelName)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Rooms.Where(c => c.Hotel.Name == HotelName).Select(e => e);
        }

        public IQueryable<Residence> GetAllResidence()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Residences;
        }       

    }
}