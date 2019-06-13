using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.Models
{
    public class BookSpecialization
    {

        [Key]
        [Display(Name = "Specialization ID")]
        public int Id { get; set; }
        [Display(Name = "Specialization")]
        public string Name { get; set; }

        [JsonIgnore]
        public virtual List<Book> Books { get; set; }
    }
}