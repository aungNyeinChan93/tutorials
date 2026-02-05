using ConsoleApp5.Database;
using ConsoleApp5.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ConsoleApp5.EFCore
{
    internal class BlogsExample
    {

        //Data Read
        public void Read()
        {
            AppDbContext db = new AppDbContext();

            var blogs = db.Blog
                .Where(b=>b.DeleteFlag == false)
                .ToList();

            foreach (var blog in blogs)
            {
                Console.WriteLine($"Blog Title {blog.Title}");
            }
        }
        

        //Create Data
        public void Create(string title,string desc,string author)
        {
            AppDbContext db = new AppDbContext();

            db.Blog.Add(new Models.BlogModel { Title = title, Description = desc, AuthorName = author, DeleteFlag = false });
            var result = db.SaveChanges();

            Console.WriteLine(result >=1 ? "Create success":"create fail");
        }

        //Get data by Id
        public void ReadById(int id = 1)
        {
            AppDbContext db = new AppDbContext();
            BlogModel? blog = db.Blog.Where(b => b.BlogId == id).FirstOrDefault();
            if (blog is null )
            {
                Console.WriteLine("Blog Not Found!");
                return;
            }
            Console.WriteLine($"Blog Title {blog.Title} and Author {blog.AuthorName} \nBlog Desc : {blog.Description}");
        }

        // Update Data
        public void Update(int id, string? title, string? desc, string? author)
        {
            AppDbContext db = new AppDbContext();

            BlogModel? blog = db.Blog
                .AsNoTracking()
                .Where((b) => b.BlogId == id)
                .FirstOrDefault() as BlogModel;

            if (blog is null)
            {
                Console.WriteLine("Blog Not Found!");
                return;
            }

            blog.Title = title;
            blog.Description = desc;
            blog.AuthorName = author;

            db.Entry(blog).State = EntityState.Modified;
            var result = db.SaveChanges();
         
            Console.WriteLine(result >= 1 ? "Update Success":"Update Fail");
        }

        // Delete Data
        public void Delete(int id)
        {
            AppDbContext db = new AppDbContext();
            var blog  = db.Blog
                .AsNoTracking()
                .Where((b)=>b.BlogId == id)
                .FirstOrDefault() as BlogModel;

            if (blog is null)
            {
                Console.WriteLine("Blog not Found!");
                return;
            }

            db.Entry(blog).State = EntityState.Deleted;
            var res = db.SaveChanges();

            Console.WriteLine(res >= 1 ? "delete success":"delete fail");
        }


    }
}
