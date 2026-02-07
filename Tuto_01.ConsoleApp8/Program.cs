


using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Database first ... ");


AppDbContext db = new AppDbContext();

var blogs =  db.TblBlogs.AsNoTracking().Where((b)=>b.DeleteFlag == true).ToList() as List<TblBlog>;


foreach (var blog in blogs)
{
    Console.WriteLine($"Blog Title is {blog.Title.ToString()}");
}

Console.WriteLine("End ... ");