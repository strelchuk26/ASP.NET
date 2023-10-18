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
	public class UserAdvertsController : Controller
	{
		private OLXDbContext ctx;
        public UserAdvertsController()
        {
			ctx = new OLXDbContext();
        }

        private void LoadCategories()
        {
            this.ViewBag.Categories = new SelectList(ctx.Categories.ToList(), "Id", "Name");
        }

        public IActionResult Index()
		{
            return this.View(ctx.UserAdverts.ToList());
        }

		[HttpGet]
		public IActionResult Create()
		{
            LoadCategories();
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> Create(UserAdvert advert, IFormFile image)
        {
            //if (!ModelState.IsValid)
            //{
            //    LoadCategories();
            //    return View(advert);
            //}

            advert.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);


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

            Advert newAdvert = new Advert()
            {
                Name = advert.Name,
                Description = advert.Description,
                Price = advert.Price,
                CategoryId = advert.CategoryId,
                Location = advert.Location,
                UserId = advert.UserId,
                ImageFile = advert.ImageFile
            };

            ctx.UserAdverts.Add(advert);
            ctx.Adverts.Add(newAdvert);
            await ctx.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var userAdvert = ctx.UserAdverts.Find(id);
            var advert = ctx.Adverts.Find();

            if (userAdvert == null) return NotFound();


            ctx.UserAdverts.Remove(userAdvert);
            ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
