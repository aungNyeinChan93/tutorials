

using System.Data;
using System.Data.SqlClient;
using System.Threading.Channels;

Console.WriteLine("Tutorial ADO module ");

string connectionStr = $"Data Source=.;Initial Catalog=KSLH_01;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\"";

SqlConnection connection = new SqlConnection(connectionStr);

connection.Open();

DataTable dt = new DataTable();

//string query = "select * from Tbl_blogs where Tbl_blogs.DeleteFlag != 1";
string query = @"select *
    from tbl_blogs
    where tbl_blogs.DeleteFlag = 0
 ";

SqlCommand cmd = new SqlCommand(query,connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
adapter.Fill(dt);

//SqlDataReader reader = cmd.ExecuteReader();

//while (reader.Read())
//{
//    Console.WriteLine($"Blog Title is {reader["Title"]}");
//}


// Data Insert
Console.WriteLine("Enter Title");
string title = Console.ReadLine();
Console.WriteLine("Enter Description ");
string desc = Console.ReadLine();
Console.WriteLine("Enter Author ");
string author = Console.ReadLine();


//string insertQuery = $@"insert into tbl_blogs 
//    values ('{title}','{desc}','{author}',0)
//";

string insertQuery = @"INSERT INTO [dbo].[Tbl_Blogs]
           ([Title]
           ,[Description]
           ,[AuthorName]
           ,[DeleteFlag])
     VALUES
           (@Title
           ,@Description
           ,@AuthorName
           ,0)";


SqlCommand insertCmd = new SqlCommand(insertQuery,connection);
insertCmd.Parameters.AddWithValue("@Title",title);
insertCmd.Parameters.AddWithValue("@Description", desc);
insertCmd.Parameters.AddWithValue("@AuthorName", author);


int affectRowNumber= insertCmd.ExecuteNonQuery();

//affectRowNumber >= 1 ? Console.WriteLine("Insert Success") : Console.WriteLine("Insert fail");
Console.WriteLine(affectRowNumber >= 1 ? "Success":"fail"); 

connection.Close();

foreach (DataRow blog in dt.Rows )
{
    Console.WriteLine($"Author Name is {blog["AuthorName"]}");
    Console.Write("");
}

