using Shop.Data.Interface;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _categoryCars = new MockCategory();
        public IEnumerable<Car> Cars { 
            get {
                return new List<Car> {
                    new Car {
                        Name = "Tesla Model S",
                        ShortDesc = "Быстрый автомобиль",
                        LongDesc = "Красивый быстрый и очень тихий автомобиль компании Tesla",
                        Img = "/img/tesla model s.jpeg",
                        Price = 45000,
                        IsFavorite = true,
                        Availble = true,
                        Category = _categoryCars.AllCategories.First()
                    },
                     new Car {
                        Name = "Ford Fiesta",
                        ShortDesc = "Тихий и спокойный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/ford fiesta.jpg",
                        Price = 11000,
                        IsFavorite = false,
                        Availble = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                      new Car {
                        Name = "BMW M3",
                        ShortDesc = "Дерзкий и стильный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/bmw m3.jpg",
                        Price = 65000,
                        IsFavorite = true,
                        Availble = true,
                        Category = _categoryCars.AllCategories.Last()
                    },
                      new Car {
                        Name = "Mersedes C class",
                        ShortDesc = "Уютный и большой",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/mercedes c class.jpg",
                        Price = 40000,
                        IsFavorite = false,
                        Availble = false,
                        Category = _categoryCars.AllCategories.Last()
                    },
                      new Car {
                        Name = "Nissan Leaf",
                        ShortDesc = "Бесшумный и экономичный",
                        LongDesc = "Удобный автомобиль для городской жизни",
                        Img = "/img/nissan leaf.jpeg",
                        Price = 14000,
                        IsFavorite = true,
                        Availble = true,
                        Category = _categoryCars.AllCategories.First()
                    }
                };
            }

         
        }

        public IEnumerable<Car> GetFavCars { get ; set ; }

        public Car GetObjectCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
