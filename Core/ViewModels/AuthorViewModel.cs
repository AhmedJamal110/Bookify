using Microsoft.AspNetCore.Mvc;
using Bookify.Web.Core.Consts;

namespace Bookify.Web.Core.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(length: 100, ErrorMessage = Errors.Maxlength), Display(Name = "Authors")]
        [Remote("AllowItem", "Authors", ErrorMessage = Errors.Daplicate)]
        public string Name { get; set; } = null!;
    }
}
