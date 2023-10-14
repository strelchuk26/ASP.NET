using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace OLX.Controllers
{
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

            advert.User.Id = 1;
            advert.UserId = 1;

            if (image != null && image.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await image.CopyToAsync(memoryStream);
                    advert.ImageFile = memoryStream.ToArray();
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
    }
}
