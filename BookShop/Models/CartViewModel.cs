using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class CartViewModel
    {
        public List<CartLine> CartLines { get; set; }
        public decimal TotalPrice { get; set; }
    }
}