using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Core.Models
{

    [Index(nameof(Name), IsUnique = true)]

    public class Category : BaseModels
	{

        public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;


        public ICollection<BookCategory> Books { get; set; } = new List<BookCategory>();

    }
}
