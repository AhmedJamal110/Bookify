﻿namespace Bookify.Web.Core.ViewModels
{
    public class CategoryView
    {
       public int id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public bool IsDeleted { get; set; }
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
        public DateTime? LastUpdateDate { get; set; }
    }
}
