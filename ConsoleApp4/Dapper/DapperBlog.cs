using ConsoleApp4.Models;
using Dapper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Dapper
{
    internal class DapperBlog
    {
        private readonly string _connectionStr = $"Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\"";
        public void Read()
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
            string query = @"select * from Tbl_BLogs where DeleteFlag = 0";

            var blogs = db.Query<BlogDto>(query).ToList();

                foreach (var blog in blogs)
                {
                    Console.WriteLine($"Blog Title is {blog.Title} and Author Name is {blog.AuthorName}");
                    Console.WriteLine($"Description : {blog.Description}");
                }
            }
        }

        public void Create(string title,string desc ,string author)
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
                string query = @"insert into tbl_blogs 
                    values
                        (@Title,@Description,@AuthorName,0)";
                
                //object parameterData = new { Title =  title, Description = desc, AuthorName = author };
                var newBlog = new BlogDto() { Title = title,Description = desc ,AuthorName = author};

                int affectRecord = db.Execute(query, newBlog);

                Console.WriteLine(affectRecord >= 1 ? "Cretae Data success":"Create fail!");
            }
        }


        public void ReadById(int blogId)
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
                string query = @"select * from tbl_blogs where tbl_blogs.BlogId = @BlogId";
                //var blog = db.Query<BlogDto>(query, new {BlogId= blogId}).ToList();
                BlogDto? blog = db.Query<BlogDto>(query, new {BlogId= blogId}).FirstOrDefault();

                if(blog is null)
                {
                    Console.WriteLine("Blog Not Found!");
                    return;
                }

                Console.WriteLine($"Blog Tile  {blog?.Title} and Author Name is {blog?.AuthorName}");

                //if (blog.Count <=0)
                //{
                //    Console.WriteLine($"Blog Id Not found");
                //    return;
                //};

                //foreach (var b in blog)
                //{
                //    Console.WriteLine($"Blog Title is {b.Title}");
                //}
            }
        }

        public void Update(string title, string desc, string author,int blogId)
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
                string query = @"update Tbl_Blogs 
                set 
                    Title = @Title,
                    Description = @Description,
                    AuthorName = @AuthorName
                where Tbl_blogs.BlogId = @BlogId
                ";

                int result = db
                    .Execute(
                        query,
                        new BlogDto { Title = title, Description = desc, AuthorName = author ,BlogId =blogId });

                Console.WriteLine(result >= 1 ? "Update Success":"Update Fail!");
            }
        }

        public void Delete(int blogId)
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
                string query = @"delete from tbl_blogs where tbl_blogs.BlogId = @BlogId";

                int result = db.Execute(query, new { BlogId = blogId });
                Console.WriteLine(result >=1 ?  "Delete success":"Delete fail!");
            }
        }
    }
}
