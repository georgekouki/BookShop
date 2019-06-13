using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookShop.Controllers
{
    public class NavController : Controller
    {

        public ApplicationDbContext db = new ApplicationDbContext();

        public PartialViewResult Menu(string specialization = null)
        {

            ViewBag.SelectedSpec = specialization;

            IEnumerable<string> spec = db.Books.Select(b => b.Spec.Name).Distinct();

            return PartialView(spec);

        }
    }
}