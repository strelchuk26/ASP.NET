using DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DataAccess.Entities
{
    public class UserAdvert
    {
        CultureInfo culture = new CultureInfo("uk-UA");
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CategoryId { get; set; }
        public string UserId { get; set; }
        public byte[] ImageFile { get; set; }
        public string Description { get; set; }
        public string? Location { get; set; }
        public string Date => DateTime.Now.ToString("dd MMM", culture);
        public int? Price { get; set; }
        public Category? Category { get; set; }
        public User User { get; set; }
    }
}
