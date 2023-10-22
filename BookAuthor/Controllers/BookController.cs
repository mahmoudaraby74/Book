using BLL.Interface;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthor.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            var books = _bookRepository.GetAll();
            return View(books);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost] 
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookRepository.Add(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
                return NotFound();

            var books = _bookRepository.Get(id);

            if (books is null)
                return NotFound();


            return View(books);
        }

        [HttpGet]
		public IActionResult Update(int? id)
        {
            if (id is null)
                return NotFound();

            var books = _bookRepository.Get(id);

            if (books is null)
                return NotFound();


            return View(books);
        }
        [HttpPost]
        public IActionResult Update(int? id, Book book)
        {
            if(id !=  book.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _bookRepository.Update(book);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(book);
                }
            }
            return View(book);
        }
        public IActionResult Delete(int? id)
        {
            if(id is null)
                return NotFound();

            var book = _bookRepository.Get(id);

            if(book is null)
                return NotFound();

            _bookRepository.Delete(book);
            return RedirectToAction("Index");
        }



    }
}
