using DataAccess.Data;
using Microsoft.AspNetCore.Mvc;
using OLX.Models;
using System.Diagnostics;

namespace OLX.Controllers
{
	public class AdvertsController : Controller
	{
		private readonly OLXDbContext ctx;
		public AdvertsController(OLXDbContext ctx)
		{
			this.ctx = ctx;
		}

		public IActionResult Index()
		{
			return this.View(ctx.Adverts.ToList());
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}