using ConsoleApp4.Models;
using Dapper;
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



        public void Update(string title,string desc,string author)
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
                
            }
        }

        public void ReadById(int blogId)
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
                string query = @"select * from tbl_blogs where tbl_blogs.BlogId = @BlogId";
                var blog = db.Query<BlogDto>(query, new {BlogId= blogId}).ToList();

                if(blog.Count <=0)
                {
                    Console.WriteLine($"Blog Id Not found");
                    return;
                };

                foreach (var b in blog)
                {
                    Console.WriteLine($"Blog Title is {b.Title}");
                }
            }
        }
    }
}
