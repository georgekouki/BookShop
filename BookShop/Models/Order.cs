using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public decimal Total { get; set; }
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual ApplicationUser Customer { get; set; }

    }
}