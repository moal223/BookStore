using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        public BookController(IBookService bookService) {
            _bookService = bookService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> BookDetails(int id)
        {
            return View(await GetBook(id));
        }

        #region Methods
        private async Task<Book> GetBook(int id)
        {
            return await _bookService.FindAsync(id);
        }
        #endregion
    }
}
