using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class CartLine
    {
        public int BookId { set; get; }
        public int Quantity { get; set; }
    }
}