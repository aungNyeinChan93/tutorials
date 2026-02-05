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
    }
}
