using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Display(Name = "Название")]//Annotation replace ID with Название
        public string Name { get; set; }
        [Display(Name = "Автор")]
        public string Author { get; set; }
       // [Display(Name = "Год")]
 //       public int Year { get; set; }
        public int Price { get; internal set; }
    }
}