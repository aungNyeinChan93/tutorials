



using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;

SqlConnection connection = new SqlConnection($"Data Source=.;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\"");

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

SqlCommand cmd = new SqlCommand(selectQuery,connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
adapter.Fill(tb);

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

insertCmd.Parameters.AddWithValue("@Title",title);
insertCmd.Parameters.AddWithValue("@Description",desc);
insertCmd.Parameters.AddWithValue("@AuthorName",author);

int affectRows = insertCmd.ExecuteNonQuery();

Console.WriteLine(affectRows >=1 ? "Insert success":"insert fail");

connection.Close();

foreach (DataRow blog in tb.Rows)
{
    Console.WriteLine($"Author Name is {blog["AuthorName"]}");
}