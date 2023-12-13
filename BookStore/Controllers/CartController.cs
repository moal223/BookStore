using BookStore.Helpers;
using BookStore.Models;
using BookStore.Services;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private BookService _bookService;
        public CartController(IBookService bookService)
        {
            _bookService = (BookService)bookService;
        }

        public async Task<IActionResult> Index()
        {
            var cart = await Task.Run(() => SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart")) ?? new List<Item>();
            List<CartBookListAndTotalViewModel> items = new List<CartBookListAndTotalViewModel>();
            
            foreach(var item in cart)
            {
                items.Add(new CartBookListAndTotalViewModel { Item = item, 
                    Total = item.Book.Salary * item.Quantity});
            }
            
            ViewData["total"] = items.Sum(item => item.Total);
            return View(items);
        }
        public async Task<IActionResult> AddBook(int Id, int quantity) // id & quantity
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login", "Account");

            if(await Task.Run(() => SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart")) == null)
            {
                var cart = new List<Item>
                {
                    new Item { Book = _bookService.Find(Id), Quantity = quantity }
                };
                await Task.Run(() => SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart));
            }
            else
            {
                var cart = await Task.Run(() => SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart"));
                int index = await Task.Run(() => isExists(Id));
                if (index != -1)
                    cart[index].Quantity+=quantity;
                else
                {
                    cart.Add(new Item { Book = _bookService.Find(Id), Quantity = quantity });
                }
                await Task.Run(() => SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart));
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int id)
        {
            List<Item> cart = await Task.Run(() => SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart"));
            int index = await Task.Run(() => isExists(id));
            cart.RemoveAt(index);
            await Task.Run(() => SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart));

            ViewBag.total = await Task.Run(() => calcTotal(cart));
            return Json(ViewBag.total);
        }
        public async Task<IActionResult> EditTotalPrice(int index, int quantity)
        {
            List<Item> cart = await Task.Run(() => SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart"));
            cart[index].Quantity = quantity;
            await Task.Run(() => SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart));

            ViewBag.total = await Task.Run(() => calcTotal(cart));
            return Json(ViewBag.total);
        }

        #region Methods
        private async Task<int> isExists(int id)
        {
            var cart = await Task.Run(() => SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart"));
            for (var i = 0; i < cart.Count; i++)
                if (cart[i].Book.Id == id)
                    return i;

            return -1;
        }
        private float calcTotal(List<Item> cart)
        {
            float total = 0;
            foreach (var item in cart)
            {
                total += (item.Book.Salary * item.Quantity);
            }
            return total;
        }
        #endregion
    }
}
