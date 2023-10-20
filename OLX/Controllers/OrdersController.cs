using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace OLX.Controllers
{
    public class OrdersController : Controller
    {
        private OLXDbContext ctx;
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public OrdersController()
        {
            ctx = new OLXDbContext();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
