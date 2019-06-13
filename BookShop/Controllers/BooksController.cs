using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookShop.Models;

namespace BookShop.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);

        }

        // GET: Books/Create
        public ActionResult Create()
        {
            BookViewModel viewModel = new BookViewModel();
            viewModel.Specializations = new List<BookSpecialization>();
            viewModel.Specializations = db.Specializations.ToList();
            return View(viewModel);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel viewModel)
        {

            if (ModelState.IsValid)
            {

                db.Books.Add(FromViewModelToBook(viewModel));
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(viewModel);

        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {

            BookViewModel viewModel = new BookViewModel();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var book = db.Books.Find(id);
            viewModel = FromBookToViewModel (book);
            viewModel.Specializations = new List<BookSpecialization>();
            viewModel.Specializations = db.Specializations.ToList();


            if (viewModel == null)
            {
                return HttpNotFound();
            }
            return View(viewModel);

        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Book book = FromViewModelToBook(viewModel);
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public Book FromViewModelToBook(BookViewModel viewModel)
        {
            Book book = new Book();
            book.SpecId = viewModel.SpecId;
            book.Id = viewModel.Id;
            book.ISBN = viewModel.ISBN;
            book.Title = viewModel.Title;
            book.Price = viewModel.Price;
            book.Description = viewModel.Description;
            book.ImageUrl = viewModel.ImageUrl;

            return book;
        }


        public BookViewModel FromBookToViewModel (Book book)
        {
            BookViewModel viewModel = new BookViewModel();
            viewModel.Id = book.Id;
            viewModel.SpecId = book.SpecId;
            viewModel.ISBN = book.ISBN;
            viewModel.Title = book.Title;
            viewModel.Price = book.Price;
            viewModel.Description = book.Description;
            viewModel.ImageUrl = book.ImageUrl;

            return viewModel;
        }



    }
}
