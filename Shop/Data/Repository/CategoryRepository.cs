using Shop.Data.Interface;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CategoryRepository : ICarsCategory
    {
        private readonly ApplicationContext db;
        public CategoryRepository(ApplicationContext applicationContext)
        {
            db = applicationContext; 
        }
        public IEnumerable<Category> AllCategories => db.Category;
    }
}
