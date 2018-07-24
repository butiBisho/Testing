using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI.Models
{
    public class HotelModelFactory
    {
        public HotelModel Create(Hotel hotel)
        {
            return new HotelModel()
            {
                Name = hotel.Name,
                TelNumber = hotel.TelNumber,                
                StarRating = (int)hotel.StarRating,
                NumberOfRooms = (int)hotel.NumberOfRooms,
                Room = hotel.Rooms.Select(r => Create(r)),
                Destination = hotel.Residence.City
            };
        }

        public RoomModel Create(Room room)
        {
            return new RoomModel()
            {
                AccommodationType = room.AccommodationType,
                Facility = room.Facility,
                Theme = room.Theme,
                AccessibilityFeatures = room.AccessibilityFeatures,
                Price = (float)room.Price,
                HotelName = room.Hotel.Name,
                RoomNumber = room.RoomNumber,
                AdminID = (int)room.AdminID,
                HotelId = (int)room.HotelId,
                RoomID = (int)room.RoomID
            };
        }

        public ResidenceModel Create(Residence residence)
        {
            return new ResidenceModel()
            {
                StreetName = residence.StreetName,
                Code = residence.Code,
                City = residence.City,
                Town = residence.Town,
                Country = residence.Country,
                Hotel = residence.Hotels.Select(h => Create(h))
            };
        }
    }
}