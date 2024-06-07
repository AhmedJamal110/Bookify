using AutoMapper;
using Bookify.Web.Core.Models;
using Bookify.Web.Core.ViewModels;
using Bookify.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Controllers
{
	public class CategoriesController : Controller
	{
		private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriesController( ApplicationDbContext context , IMapper mapper) 
        {
			_context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
		{
			var category = _context.Categories.AsNoTracking().ToList();
			
			var MappedCate = _mapper.Map< IEnumerable<CategoryView>>(category);


			return View(MappedCate);
		}
		[HttpGet]	
		
		public IActionResult Create()
		{

			return PartialView("_Form");
		}

		[HttpPost]
		public IActionResult Create(CategoryViewModel model)
		{
			if (!ModelState.IsValid)
				return BadRequest();

			var categ = new Category
			{
				Name = model.Name
			};

			_context.Add(categ);
			_context.SaveChanges();

			var MappedCate = _mapper.Map<CategoryView>(categ);

			return PartialView("_CategoryRow" , MappedCate);
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

            TempData["Message"] = "Save Successfully";


            return View("_form" , viewModel);
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



		public IActionResult AllowItem(CategoryViewModel model)
		{
			var category = _context.Categories.SingleOrDefault(C => C.Name == model.Name);



			var isAllow = category is null || category.id == model.Id;

			return Json(isAllow);


		}

	}
}
