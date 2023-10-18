using Microsoft.EntityFrameworkCore;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Globalization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccess.Data
{
	public class OLXDbContext : IdentityDbContext<User>
	{
		public OLXDbContext() { }
		public OLXDbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OLXDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>().HasData(new[] 
			{
                new Category() { Id = 1, Name = "Electronics" },
                new Category() { Id = 2, Name = "Sport" },
                new Category() { Id = 3, Name = "Fashion" },
                new Category() { Id = 4, Name = "Home & Garden" },
                new Category() { Id = 5, Name = "Transport" },
                new Category() { Id = 6, Name = "Toys & Hobbies" },
                new Category() { Id = 7, Name = "Musical Instruments" },
                new Category() { Id = 8, Name = "Art" }
            });

            //modelBuilder.Entity<User>().HasData(new[] 
            //{
            //    new User() { Id = 1, Email = "2e2@gamil.com" }
            //});

            //modelBuilder.Entity<Advert>().HasData(new[]
            //{
            //    new Advert() 
            //    {
            //        Id = 1,
            //        Name = "Salomon XT-6 Gore-Tex",
            //        CategoryId = 3,
            //        Description = "dsadasdas",
            //        Location = "Kyiv",
            //        Price = 3999,
            //        UserId = 1,
            //        ImageFile = new byte[] { 1, 3, 5 }
            //    }
            //});
        }

        public DbSet<Advert> Adverts { get; set; }
		public DbSet<UserAdvert> UserAdverts { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
