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
            return this.View(ctx.Orders.ToList());
        }

        public IActionResult Create(int id)
        {
            var items = ctx.Adverts.Include(x => x.Category).Include(x => x.User).ToList();
            var item = items.Find(x => x.Id == id);
            if (item == null) return NotFound();

            var adverts = new List<Advert> { item };

            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = CurrentUserId,
                Adverts = adverts
            };

            ctx.Orders.Add(order);
            ctx.Adverts.Remove(item);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
