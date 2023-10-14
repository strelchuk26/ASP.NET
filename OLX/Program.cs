using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;
using Microsoft.AspNetCore.Identity;

namespace OLX
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
            string connStr = builder.Configuration.GetConnectionString("LocalDb");

            builder.Services.AddControllersWithViews();

			builder.Services.AddDbContext<OLXDbContext>(opts => opts.UseSqlServer(connStr));

               builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<OLXDbContext>();

            builder.Services.AddFluentValidationAutoValidation();
			builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDistributedMemoryCache();

            var app = builder.Build();

			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Adverts/Error");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
            app.UseAuthentication();;

			app.UseAuthorization();

			app.MapRazorPages();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Adverts}/{action=Index}/{id?}");

			app.Run();
		}
	}
}