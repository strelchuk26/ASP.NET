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
using System.Diagnostics.Metrics;

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
                new Category() { Id = 1, Name = "Електроніка" },
                new Category() { Id = 2, Name = "Спорт" },
                new Category() { Id = 3, Name = "Мода та одяг" },
                new Category() { Id = 4, Name = "Сад і дім" },
                new Category() { Id = 5, Name = "Запчастини, транспорт" },
                new Category() { Id = 6, Name = "Іграшки та хоббі" },
                new Category() { Id = 7, Name = "Музичні інструменти" },
                new Category() { Id = 8, Name = "Мистецтво" }
            });
        }


        public DbSet<Advert> Adverts { get; set; }
		public DbSet<Category> Categories { get; set; }
	}
}
