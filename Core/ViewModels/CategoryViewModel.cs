using Microsoft.AspNetCore.Mvc;

namespace Bookify.Web.Core.ViewModels
{

    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Remote("AllowItem", "Categories", ErrorMessage ="category is alredy Exsit")]
        public string Name { get; set; } = null!;


    }
}
