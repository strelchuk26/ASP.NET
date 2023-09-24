using Microsoft.AspNetCore.Mvc;
using OLX.Models;
using System.Diagnostics;

namespace OLX.Controllers
{
	public class HomeController : Controller
	{
		public HomeController()
		{
			
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Profile()
		{
			return View();
		}

		public IActionResult Products()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}