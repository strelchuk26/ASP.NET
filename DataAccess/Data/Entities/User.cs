using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
	public class User : IdentityUser
	{
		public ICollection<Advert> Adverts { get; set; }
		public ICollection<UserAdvert> UserAdverts { get; set; }
	}
}
