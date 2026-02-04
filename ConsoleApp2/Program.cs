

using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Tutorial ADO module ");

string connectionStr = $"Data Source=.;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\"";

SqlConnection connection = new SqlConnection(connectionStr);

connection.Open();

DataTable dt = new DataTable();

string query = "select * from KSLH_01.dbo.Tbl_blogs where Tbl_blogs.DeleteFlag != 1";

SqlCommand cmd = new SqlCommand(query,connection);
SqlDataAdapter adapter = new SqlDataAdapter(cmd);
adapter.Fill(dt);

SqlDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine($"Blog Title is {reader["Title"]}");
}


connection.Close();


foreach (DataRow blog in dt.Rows )
{
    Console.WriteLine($"Author Name is {blog["AuthorName"]}");
    Console.Write("");
}

