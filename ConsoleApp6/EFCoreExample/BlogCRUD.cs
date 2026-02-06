using ConsoleApp6.Database;
using ConsoleApp6.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp6.EFCoreExample
{
    internal class BlogCRUD
    {
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var blogs = db.blog
                .AsNoTracking()
                .Where(b=>b.DeleteFlag != true)
                .ToArray();

            foreach (var blog in blogs)
            {
                Console.WriteLine($"Blog Title is {blog.Title}");
            }
        }

        public void Create(string title,string desc,string author)
        {
            AppDbContext db = new AppDbContext();
            db.blog.Add(new BlogModel { Title = title, Description = desc, AuthorName = author, DeleteFlag = false });
            var result = db.SaveChanges();

            Console.WriteLine(result >=1 ? "Create Success":"Create Fail");
        }

        public void Update(int id,string? title = null ,string? desc = null,string? author = null)
        {
            AppDbContext db = new AppDbContext();
            var blog =  db.blog.AsNoTracking().Where(b => b.BlogId == id).FirstOrDefault() as BlogModel;

            if(blog is null)
            {
                Console.WriteLine("Update Blog Not Found!");
                return;
            }

            if (title is not null)
            {
                blog.Title = title;
            }

            if(desc is not null)
            {
                blog.Description = desc;
            }

            if(author is not null)
            {
                blog.AuthorName = author;
            }

            db.Entry(blog).State = EntityState.Modified;
            var result = db.SaveChanges();

            Console.WriteLine(result >=1 ? "Update success":"update fail");

        }

        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            var blog = db.blog.AsNoTracking().Where(b => b.BlogId == id).FirstOrDefault();

            if(blog is null)
            {
                Console.WriteLine("Delete blog not found!");
                return;
            }

            db.Entry(blog).State = EntityState.Deleted;
            int result = db.SaveChanges();
            Console.WriteLine(result >=1 ? "Delete success":"delete fail");
        }
    }
}
