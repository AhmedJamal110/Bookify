using Bookify.Web.Core.Consts;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Web.Core.ViewModels
{

    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength( length:100 , ErrorMessage =Errors.Maxlength) ,Display(Name = "Category")]
        [Remote("AllowItem", "Categories", ErrorMessage =Errors.Daplicate)]
        public string Name { get; set; } = null!;


    }
}
