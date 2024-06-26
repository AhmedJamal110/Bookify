using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Bookify.Web.Core.Models
{
    [Index(nameof(Name), IsUnique = true)]

    public class Author : BaseModels
    {
        public int Id { get; set; }

        [MaxLength(length:100)]
        public string Name { get; set; }
    }
}
