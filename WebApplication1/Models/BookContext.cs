using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class BookContext : DbContext
    {
        public BookContext() : base("name = BookContext")
        {
            Books.Add(new Book() { Name = "Poxos", Author = "Pestros", Price = 1548, Id = 1 });
            Books.Add(new Book() { Name = "C++", Author = "Pestros", Price = 1548, Id = 1 });


        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<University.Models.Course> Courses { get; set; }
    }
}