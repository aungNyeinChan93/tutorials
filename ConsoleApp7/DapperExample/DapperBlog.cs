using ConsoleApp7.DapperDto;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ConsoleApp7.DapperExample
{
    internal class DapperBlog
    {
        private readonly string _connectionStr = $"Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\"";

        public void Read()
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
                string query = @"select * from Tbl_blogs where tbl_blogs.DeleteFlag = 0";
                var blogs = db.Query<BlogDto>(query).ToList();

                foreach (var blog in blogs)
                {
                    Console.WriteLine($"Author Name {blog.AuthorName}");
                }
            }
        }

        public void Create(string title ,string desc,string author)
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
                int res = db.Execute(@"insert into tbl_blogs 
                            values (@Title,@Description, @AuthorName,0)",
                            new BlogDto {Title =title,Description = desc,AuthorName= author });

                Console.WriteLine(res >=1 ? "create success":"create fail!");
            }
        }

        public void Update(int id,string title,string desc,string author)
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
                string query = @"UPDATE [dbo].[Tbl_Blogs]
                   SET [Title] = @Title
                      ,[Description] = @Description
                      ,[AuthorName] = @AuthorName
                 WHERE Tbl_Blogs.BlogId = @BlogId
                    ";

                int res = db.Execute(query, new BlogDto { Title = title, Description = desc, AuthorName = author ,BlogId = id });

                Console.WriteLine(res >= 1 ? "Update success":"update Fail");
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(this._connectionStr))
            {
              int result =  db.Execute("delete from tbl_blogs where BlogId = @BlogId",new{ BlogId = id });
                Console.WriteLine(result >= 1 ? " Delete Success":"delete fail");
            }
        }


    }
}
