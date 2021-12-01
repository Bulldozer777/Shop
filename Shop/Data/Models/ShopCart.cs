using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Models
{
    public class ShopCart
    {
        private readonly ApplicationContext db;
        public ShopCart(ApplicationContext applicationContext)
        {
            db = applicationContext;

        }
        public string ShopCartId { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = service.GetService<ApplicationContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);
            return new ShopCart(context) { ShopCartId = shopCartId };
        }
        public void AddToCart(Car car)
        {         
            db.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                Car = car,
                Price = car.Price
            });
            db.SaveChanges();
        }
        public List<ShopCartItem> GetShopItems()
        {
            return db.ShopCartItem.Where(c => c.ShopCartId == ShopCartId).Include(s => s.Car).ToList();
        }
    }
}
