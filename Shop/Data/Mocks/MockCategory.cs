using Shop.Data.Interface;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories { get {
                return new List<Category> { new Category {CategotyName = "Электромобили" , Desc = "Современный вид транспорта" },
                                            new Category {CategotyName = "Класические автомобили" , Desc = "Машины с двигателем внутреннего згорания" }
                };
            }
        }
    }
}
