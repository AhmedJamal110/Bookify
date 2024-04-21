﻿using Bookify.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Web.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CategoriesController( ApplicationDbContext context) 
        {
			_context = context;
		}
        public IActionResult Index()
		{
			var category = _context.Categories.ToList();

			return View(category);
		}
	}
}