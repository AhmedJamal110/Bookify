﻿namespace Bookify.Web.Core.Models
{
    public class BookCategory : BaseModels
    {
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }

    }

}
