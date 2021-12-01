using Microsoft.EntityFrameworkCore;
using Shop.Data.Interface;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly ApplicationContext db;
        public CarRepository(ApplicationContext applicationContext)
        {
            db = applicationContext;

        }
        public IEnumerable<Car> Cars => db.Car.Include(c => c.Category);
        public IEnumerable<Car> GetFavCars => db.Car.Where(p => p.IsFavorite).Include(c => c.Category);

        public Car GetObjectCar(int carId) => db.Car.FirstOrDefault(p => p.Id == carId);

    }
}
