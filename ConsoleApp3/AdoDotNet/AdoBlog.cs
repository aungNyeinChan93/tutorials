using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.AdoDotNet
{
    internal class AdoBlog
    {
        public void Read(SqlConnection connection)
        {
            connection.Open();
            DataTable tb = new DataTable();

            string selectQuery = @"
                SELECT [BlogId]
                      ,[Title]
                      ,[Description]
                      ,[AuthorName]
                      ,[DeleteFlag]
                  FROM [KSLH_01].[dbo].[Tbl_Blogs]
                  WHERE Tbl_Blogs.DeleteFlag = 0
                ";

            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tb);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"Blog Title is {reader["Title"]}");
            }

            connection.Close();
            foreach (DataRow blog in tb.Rows)
            {
                Console.WriteLine($"Author Name is {blog["AuthorName"]}");
            }
        }

        public void Create(SqlConnection connection)
        {

            connection.Open();

            //Inset data
            string insetQuery = @"INSERT INTO [KSLH_01].[dbo].[Tbl_Blogs]
                   ([Title]
                   ,[Description]
                   ,[AuthorName]
                   ,[DeleteFlag])
             VALUES
                   (@Title,
                   @Description,
                   @AuthorName,
                   0)";

            Console.WriteLine("Insert Data");
            Console.WriteLine("Enter Title");
            string title = Console.ReadLine();
            Console.WriteLine("Enter Description");
            string desc = Console.ReadLine();
            Console.WriteLine("Enter Author ");
            string author = Console.ReadLine();

            Console.WriteLine("Start data insert  ... ");

            SqlCommand insertCmd = new SqlCommand(insetQuery, connection);

            insertCmd.Parameters.AddWithValue("@Title", title);
            insertCmd.Parameters.AddWithValue("@Description", desc);
            insertCmd.Parameters.AddWithValue("@AuthorName", author);

            int affectRows = insertCmd.ExecuteNonQuery();

            Console.WriteLine(affectRows >= 1 ? "Insert success" : "insert fail");

            connection.Close();

        }

        public void ReadById(SqlConnection connection)
        {
            connection.Open();

            Console.WriteLine("Enter Blog Id");
            
            bool isSuccess = int.TryParse(Console.ReadLine(), out int BlogId);
            if(!isSuccess)
            {
                Console.WriteLine("Blog id must be interger ");
                return;
            }

            string query = @"SELECT [BlogId]
                  ,[Title]
                  ,[Description]
                  ,[AuthorName]
                  ,[DeleteFlag]
              FROM [KSLH_01].[dbo].[Tbl_Blogs]
              where Tbl_Blogs.BlogId = @BlogId";



            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", BlogId);
            DataTable tb = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(tb);

            if(tb.Rows.Count < 1)
            {
                Console.WriteLine($"Blog Data not found!");
                return;
            }

            DataRow blog = tb.Rows[0];

            Console.WriteLine($"Blog title is {blog["title"]} and author name is {blog["AuthorName"]}");

            connection.Close();
        }
        public void Update(SqlConnection connection)
        {
            connection.Open();

            Console.WriteLine("Blog data update case ... ");

            string query = @"
            update [KSLH_01].[dbo].[Tbl_Blogs] 
            set	
	            Title = @Title,
	            Description = @Description,
	            AuthorName = @Author,
	            DeleteFlag = 0
            where [KSLH_01].[dbo].[Tbl_Blogs].BlogId = @BlogId";

            Console.Write("Enter Update Title ");
            string title = Console.ReadLine();


            Console.Write("Enter Update Description ");
            string desc = Console.ReadLine();

            Console.Write("Enter Update AuthorName ");
            string author = Console.ReadLine();

            Console.Write("Enter Update Blog Id ");
            string blogId = Console.ReadLine();

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue ("@title", title);
            cmd.Parameters.AddWithValue ("@Description", desc);
            cmd.Parameters.AddWithValue ("@Author", author);
            cmd.Parameters.AddWithValue ("@BlogId",blogId );

            int affectRows = cmd.ExecuteNonQuery();

            Console.WriteLine(affectRows >=1 ? "Update success":"update fail");

            connection.Close();

        }

        public void Delete(SqlConnection connection)
        {
            connection.Open();

            Console.WriteLine("Blog Delete ....");

            Console.WriteLine("Enter Blog Id");
            string blogId = Console.ReadLine();

            string query = @"delete from [KSLH_01].[dbo].[Tbl_Blogs]
                where [KSLH_01].[dbo].[Tbl_Blogs].BlogId = @BlogId
                ";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("BlogId",blogId);

            int affectRow = cmd.ExecuteNonQuery();

            Console.WriteLine(affectRow >=1 ? "Delete success":"delete fail");

            connection.Close();
        }
    }
}
