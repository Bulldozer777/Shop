﻿using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interface;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;
        public CarsController(IAllCars iAllCars, ICarsCategory iCarsCat)
        {
            _allCars = iAllCars;
            _allCategories = iCarsCat;

        }
        public ViewResult List()
        {
            ViewBag.Title = "Страница с автомобилями";
            CarsListViewModel obj = new CarsListViewModel();
            obj.AllCars = _allCars.Cars;
            obj.CurrCategory = "Автомобили";
            return View(obj);
        }
    }
}
