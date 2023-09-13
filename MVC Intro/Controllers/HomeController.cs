using Microsoft.AspNetCore.Mvc;
using MVC_Intro.Models;
using System.Diagnostics;

namespace MVC_Intro.Controllers
{
	public class HomeController : Controller
	{
		public HomeController()
		{
			
		}

		public IActionResult GeneralInfo()
		{
			return View();
		}

		public IActionResult MVCModel()
		{
			return View();
		}

		public IActionResult MVCView()
		{
			return View();
		}

		public IActionResult MVCController()
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