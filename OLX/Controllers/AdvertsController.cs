using DataAccess.Data;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System.Drawing;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

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
            var adverts = ctx.Adverts.Where(x => x.UserId == CurrentUserId).Include(x => x.Category).ToList();
            return this.View(adverts);
        }

        public IActionResult Advert(int id)
        {
            var items = ctx.Adverts.Include(x => x.Category).Include(x => x.User).ToList();
            var item = items.Find(x => x.Id == id);
            if (item == null) return NotFound();

            return View(item);
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
                string placeholderImagePath = Path.Combine(Environment.CurrentDirectory, "wwwroot\\img\\placeholder.png");

                using (var ms = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(placeholderImagePath, FileMode.Open, FileAccess.Read))
                    {
                        fs.CopyTo(ms);
                    }

                    advert.ImageFile = ms.ToArray();
                }
            }

            if (advert.Description == null)
            {
                LoadCategories();
                return View(advert);
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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = ctx.Adverts.Find(id);

            if (item == null) return NotFound();

            LoadCategories();

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Advert advert, IFormFile image)
        {
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
                string placeholderImagePath = Path.Combine(Environment.CurrentDirectory, "wwwroot\\img\\placeholder.png");

                using (var ms = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(placeholderImagePath, FileMode.Open, FileAccess.Read))
                    {
                        fs.CopyTo(ms);
                    }

                    advert.ImageFile = ms.ToArray();
                }
            }

            if (advert.Description == null)
            {
                LoadCategories();
                return View(advert);
            }

            ctx.Adverts.Update(advert);
            ctx.SaveChanges();

            return RedirectToAction("MyAdverts");
        }
    }
}
