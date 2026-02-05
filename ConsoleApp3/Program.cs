



using ConsoleApp3.AdoDotNet;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices.ComTypes;


SqlConnection connection = new SqlConnection($"Data Source=.;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"SQL Server Management Studio\"");

AdoBlog readBlog = new AdoBlog();

//Read data
readBlog.Read(connection);

//// Create Data
readBlog.Create(connection);

//Edit Data
readBlog.ReadById(connection);

//Update Data
readBlog.Update(connection);

// Delete Data
readBlog.Delete(connection);




