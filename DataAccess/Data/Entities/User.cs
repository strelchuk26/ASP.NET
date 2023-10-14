namespace DataAccess.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public ICollection<Advert> Adverts { get; set; }
		public ICollection<UserAdvert> UserAdverts { get; set; }
	}
}
