using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(ApplicationContext context)
        {
            
            if(!context.Category.Any())
            {
                context.Category.AddRange(Categories.Select(c => c.Value));
            }
            if (!context.Category.Any())
            {
                context.AddRange(
                    new Car
                    {
                        Name = "Tesla Model S",
                        ShortDesc = "Быстрый автомобиль",
                        LongDesc = "Красивый быстрый и очень тихий автомобиль компании Tesla",
                        Img = "/img/tesla model s.jpeg",
                        Price = 45000,
                        IsFavorite = true,
                        Availble = true,
                        Category = Categories["Электромобили"]
                    },
                     new Car
                     {
                         Name = "Ford Fiesta",
                         ShortDesc = "Тихий и спокойный",
                         LongDesc = "Удобный автомобиль для городской жизни",
                         Img = "/img/ford fiesta.jpg",
                         Price = 11000,
                         IsFavorite = false,
                         Availble = true,
                         Category = Categories["Классические автомобили"]
                     },
                      new Car
                      {
                          Name = "BMW M3",
                          ShortDesc = "Дерзкий и стильный",
                          LongDesc = "Удобный автомобиль для городской жизни",
                          Img = "/img/bmw m3.jpg",
                          Price = 65000,
                          IsFavorite = true,
                          Availble = true,
                          Category = Categories["Классические автомобили"]
                      },
                      new Car
                      {
                          Name = "Mersedes C class",
                          ShortDesc = "Уютный и большой",
                          LongDesc = "Удобный автомобиль для городской жизни",
                          Img = "/img/mercedes c class.jpg",
                          Price = 40000,
                          IsFavorite = false,
                          Availble = false,
                          Category = Categories["Классические автомобили"]
                      },
                      new Car
                      {
                          Name = "Nissan Leaf",
                          ShortDesc = "Бесшумный и экономичный",
                          LongDesc = "Удобный автомобиль для городской жизни",
                          Img = "/img/nissan leaf.jpeg",
                          Price = 14000,
                          IsFavorite = true,
                          Availble = true,
                          Category = Categories["Электромобили"]
                      }) ;
            }
            context.SaveChanges();
        }
        private static Dictionary<string, Category> category;
        public static Dictionary<string, Category> Categories
        { 
            get {
                if (category == null)
                {
                    var list = new Category[] {
                        new Category { CategotyName = "Электромобили", Desc = "Современный вид транспорта" },
                        new Category { CategotyName = "Классические автомобили", Desc = "Машины с двигателем внутреннего згорания" }
                    };
                    category = new Dictionary<string, Category>();
                    foreach (Category Element in list)
                    {
                        category.Add(Element.CategotyName, Element);
                    }
                }
                return category;

            }
        }
    }
}
