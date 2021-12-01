using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interface;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;

        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
        }

        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                FavCars = _carRep.GetFavCars
            };
            return View(homeCars);
        }
        //public async Task<IActionResult> Index()
        //{
        //    return View(await db.Car.ToListAsync());
        //}
        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> Create(User user)
        //{
        //    db.Users.Add(user);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
