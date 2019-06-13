using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(string specialization)
        {

            List<BookViewModel> booksList = new List<BookViewModel>();
            IEnumerable<Book> books;


            books = db.Books
               .Where(b => specialization == null || b.Spec.Name == specialization)
             .OrderBy(b => b.ISBN);


            foreach (var item in books)
            {
                booksList.Add(new BookViewModel
                {
                    Id = item.Id,
                    ISBN = item.ISBN,
                    Title = item.Title,
                    Description = item.Description,
                    ImageUrl = item.ImageUrl,
                    Price = item.Price,
                    SpecId = item.SpecId,
                });

            }

            return View(booksList);
        }

       
 
    
    } 

}