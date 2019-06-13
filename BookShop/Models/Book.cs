using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public long ISBN { get; set; }
        public string Title { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int SpecId { get; set; }
        [ForeignKey("SpecId")]
        public virtual BookSpecialization Spec { get; set; }

    }
}