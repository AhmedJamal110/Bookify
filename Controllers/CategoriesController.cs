using Bookify.Web.Core.Models;
using Bookify.Web.Core.ViewModels;
using Bookify.Web.Data;
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
		[HttpGet]	
		
		public IActionResult Create()
		{

			return View();
		}

		[HttpPost]
		public IActionResult Create(CategoryViewModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			var categ = new Category
			{
				Name = model.Name
			};

			_context.Add(categ);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		public IActionResult Edit( int id)
		{
		
			var categoty = _context.Categories.Find(id);

			if (categoty is null)
				return NotFound();

			var viewModel = new CategoryViewModel
			{
				Id = id,
				Name = categoty.Name

			};

			return View(viewModel);
		}
	

		[HttpPost]
		public IActionResult Edit(CategoryViewModel model)
		{
			if (ModelState.IsValid)
			{
				var category = _context.Categories.Find(model.Id);

				if (category is null)
					return NotFound();

				category.Name = model.Name;
				category.LastUpdateDate = DateTime.Now;
				_context.SaveChanges();
			
				return RedirectToAction(nameof(Index));
			}

			return View(model);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult ToggelStaures(int id)
		{
			var category = _context.Categories.Find(id);
			if (category is null)
				return NotFound();

			category.IsDeleted = !category.IsDeleted;
			var lastUodatedOn = category.LastUpdateDate = DateTime.Now;

			_context.SaveChanges();

			return Ok(lastUodatedOn.ToString());		
		}

	}
}
