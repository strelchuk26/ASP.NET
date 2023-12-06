using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace OLX.Controllers
{
    public class OrdersController : Controller
    {
        private OLXDbContext ctx;
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public OrdersController(OLXDbContext ctx)
        {
            this.ctx = ctx;
        }

        public IActionResult Index()
        {
            var orders = ctx.Orders.Where(x => x.BuyerId == CurrentUserId).ToList();
            return View(orders);
        }


        // action for show view
        public IActionResult Create(int id)
        {
            var items = ctx.Adverts.Include(x => x.Category).Include(x => x.User).ToList();
            var item = items.Find(x => x.Id == id);

            if (item == null) return NotFound();

            return View(item);
        }


        // action for create order
        public IActionResult CreateOrder(int advertId)
        {
            var adverts = ctx.Adverts.Include(x => x.Category).Include(x => x.User).ToList();
            var advert = adverts.Find(x => x.Id == advertId); 
            if (advert == null) return NotFound();

            var order = new Order()
            {
                Date = DateTime.Now,
                BuyerId = CurrentUserId,
                UserId = advert.UserId,
                AdvertId = advert.Id,
                Price = advert.Price
            };

            ctx.Orders.Add(order);
            ctx.Adverts.Remove(advert);
            ctx.SaveChanges();

            return RedirectToAction("Index", "Orders");
        }
    }
}
