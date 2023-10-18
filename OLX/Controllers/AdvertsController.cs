using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Security.Claims;

namespace OLX.Controllers
{
    [Authorize]
	public class AdvertsController : Controller
	{
		private OLXDbContext ctx;
        private string CurrentUserId => User.FindFirstValue(ClaimTypes.NameIdentifier);

        public AdvertsController()
        {
			ctx = new OLXDbContext();
        }

        private void LoadCategories()
        {
            this.ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
        }

        public IActionResult Index()
		{
            return this.View(ctx.Adverts.ToList());
        }

        public IActionResult MyAdverts()
        {
            var adverts = ctx.Adverts.Where(x => x.UserId == CurrentUserId);
            return this.View(adverts.ToList());
        }

        [HttpGet]
		public IActionResult Create()
		{
            LoadCategories();
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Create(Advert advert, IFormFile image)
        {
            //if (!ModelState.IsValid)
            //{
            //    LoadCategories();
            //    return View(advert);
            //}

            advert.UserId = CurrentUserId;

            if (image != null && image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    advert.ImageFile = memoryStream.ToArray();
                }
            }
            else
            {
                string placeholderImagePath = "~/img/placeholder.png";

                using (var ms = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(placeholderImagePath, FileMode.Open, FileAccess.Read))
                    {
                        fs.CopyTo(ms);
                    }

                    advert.ImageFile = ms.ToArray();
                }
            }

            ctx.Adverts.Add(advert);
            await ctx.SaveChangesAsync();

            return RedirectToAction("MyAdverts");
        }

        public IActionResult Delete(int id)
        {
            var advert = ctx.Adverts.Find(id);

            if (advert == null) return NotFound();


            ctx.Adverts.Remove(advert);
            ctx.SaveChanges();

            return RedirectToAction("MyAdverts");
        }
    }
}
