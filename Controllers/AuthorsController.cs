using AutoMapper;
using Bookify.Web.Core.Models;
using Bookify.Web.Core.ViewModels;
using Bookify.Web.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookify.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(ApplicationDbContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
           var authors =  _context.Authors.AsNoTracking().ToList();

            var authorsMappedc = _mapper.Map<IEnumerable<AuthorView>>(authors);
            return View(authorsMappedc);
        }

        [HttpGet]

        public IActionResult Create()
        {

            return PartialView("_AuthorForm");
        }

        [HttpPost]
        public IActionResult Create(AuthorViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var author = new Author
            {
                Name = model.Name
            };

            _context.Add(author);
            _context.SaveChanges();

            var AuthorMapping  = _mapper.Map<AuthorView>(author);

            return PartialView("_AuthorsRow", AuthorMapping);
        }


        //
        public IActionResult Edit(int id)
        {

            var author = _context.Authors.Find(id);

            if (author is null)
                return NotFound();

            var viewModel = new AuthorViewModel
            {
                Id = id,
                Name = author.Name

            };

            TempData["Message"] = "Save Successfully";


            return View("_AuthorForm", viewModel);
        }


        [HttpPost]
        public IActionResult Edit(AuthorViewModel model)
        {
            if (ModelState.IsValid)
            {
                var author = _context.Authors.Find(model.Id);

                if (author is null)
                    return NotFound();

                author.Name = model.Name;
                author.LastUpdateDate = DateTime.Now;
                _context.SaveChanges();



                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggelStaures(int id)
        {
            var author = _context.Authors.Find(id);
            if (author is null)
                return NotFound();

            author.IsDeleted = !author.IsDeleted;
            var lastUodatedOn = author.LastUpdateDate = DateTime.Now;

            _context.SaveChanges();

            return Ok(lastUodatedOn.ToString());
        }



        public IActionResult AllowItem(AuthorViewModel model)
        {
            var author = _context.Authors.SingleOrDefault(C => C.Name == model.Name);



            var isAllow = author is null || author.Id == model.Id;

            return Json(isAllow);


        }


    }
}
