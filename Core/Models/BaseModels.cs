namespace Bookify.Web.Core.Models
{
    public class BaseModels
    {
 
        public DateTime DateOfCreation { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
