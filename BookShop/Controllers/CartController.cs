using BookShop.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace BookShop.Controllers
{
    public class CartController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cart
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult CreateOrder()
        {
            return View();
        }

        public string FindProduct(int productId, int quantity)
        {
            var newObj = new { book = db.Books.FirstOrDefault(b => b.Id == productId), qty = quantity };
            return JsonConvert.SerializeObject(newObj);

            
        }

        public ActionResult Checkout(string orderNumber)
        {
            return View((object)orderNumber);
        }
        [HttpPost]
        public ActionResult Checkout(List<OrderRow> cart)
        {


            if (!((System.Web.HttpContext.Current.User != null) &&
                System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return Json(new {newUrl = Url.Action("Login", "Account")});
            }
            decimal totalPrice = 0;
            var cartViewModel = new CartViewModel {CartLines = new List<CartLine>()};
           
            foreach (var row in cart)
            {
                
                var book = db.Books.FirstOrDefault(r => r.Id == row.BookId);
                OrderRow newOrderRow = new OrderRow();
                newOrderRow.BookId = book.Id;
                var cartLine = new CartLine
                {
                    BookId = row.BookId,
                    Quantity = row.Quantity
                };
                cartViewModel.CartLines.Add(cartLine);
                totalPrice = totalPrice + (book.Price * row.Quantity);
            }
            var newOrder = new Order
            {
                CustomerId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                Total = totalPrice
            };
            db.Orders.Add(newOrder);
            db.SaveChanges();
            var order = new Order {Total = totalPrice};
            cartViewModel.TotalPrice = totalPrice;
           
            return Json(new { newUrl = Url.Action("Checkout", "Cart", new { orderNumber = "12345" }) });


        }


    }
}