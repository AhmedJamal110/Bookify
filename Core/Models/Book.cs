using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Core.Models
{
    [Index(nameof(Title) , nameof(AuthorId) , IsUnique =true)]
    public class Book : BaseModels
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        [MaxLength(length: 500)]
        public string Publisher { get; set; } = null!;
        public DateTime PublisherDate { get; set; }

        public string ImageUrl { get; set; }

        public string Hall { get; set; }
        public string Description { get; set; } = null!;
        public bool  IsAvailableFrReting { get; set; }
        public int AuthorId { get; set; }
        public Author? Author { get; set; }


        public ICollection<BookCategory> Categories { get; set; } = new List<BookCategory>();
    }
}
