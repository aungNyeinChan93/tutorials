using ConsoleApp5.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5.EFCore
{
    internal class BlogsExample
    {

        //Data Read
        public void Read()
        {
            AppDbContext db = new AppDbContext();

            var blogs = db.Blog.ToList();

            foreach (var blog in blogs)
            {
                Console.WriteLine($"Blog Title {blog.Title}");
            }
        }


    }
}
