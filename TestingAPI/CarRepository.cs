using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingAPI
{
    public class CarRepository
    {
        public IQueryable<Car> GetAllCars()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Cars;
        }

        public IQueryable<Car> GetAllCarsByLocationDate(string location, DateTime date)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Cars.Where(c => c.Location == location & c.Date == date).Select(e => e);
        }

        public IQueryable<Supplier> GetAllSuppliers()
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Suppliers;
        }

        public IQueryable<Supplier> GetAllSuppliers(int id)
        {
            BootCampEntities ctx = new BootCampEntities();
            return ctx.Suppliers.Where(c => c.SupplierId == id).Select(e => e);
        }
    }
}