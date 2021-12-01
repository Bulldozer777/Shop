using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Interface
{
  public  interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
