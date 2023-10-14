namespace DataAccess.Entities
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Advert> Adverts { get; set; }
		public ICollection<UserAdvert> UserAdverts { get; set; }
	}
}
