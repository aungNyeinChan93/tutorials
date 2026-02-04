using System.Data;
using System.Data.SqlClient;


Console.WriteLine("Hello, World!");
Console.WriteLine("Hi ");

bool isSuccess = int.TryParse(Console.ReadLine(),out int num);

if (isSuccess)
{
    Console.WriteLine(num);
}


// Connect to database (Data layer)

string connectionStr = $"Data Source=.;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\"";

Console.WriteLine($"Connection str {connectionStr} was start conneecting");

SqlConnection connection  = new SqlConnection(connectionStr);

Console.WriteLine("Connection open");
connection.Open();

string query = "select * from KSLH_01.dbo.Tbl_blogs where Tbl_blogs.DeleteFlag != 1";
//string query = @"SELECT [BlogId]
//      ,[Title]
//      ,[Description]
//      ,[AuthorName]
//      ,[DeleteFlag]
//  FROM [KSLH_01].[dbo].[Tbl_Blogs]";

SqlCommand cmd = new SqlCommand(query,connection);

//user adapter
//DataTable dt = new DataTable();
//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//adapter.Fill(dt);

// use Reader for record by record
SqlDataReader bdr = cmd.ExecuteReader();

//Presentation Layer
while (bdr.Read())
{
        Console.WriteLine($" Blog Title is {bdr["Title"]} and Author name is {bdr["AuthorName"]}");
}


connection.Close();
Console.WriteLine("Connection close");

//Presentation Layer
//foreach (DataRow dr in dt.Rows)
//{
//    Console.WriteLine($" Blog Title : {dr["Title"]} and Author Name is {dr["AuthorName"]}");
//}

Console.Read(); 

