using ConsoleApp4.Dapper;



DapperBlog dapperBlog = new DapperBlog();

//dapperBlog.Read();
//dapperBlog.Create("Test Title", "Test Desc ", "Ronaldo");
dapperBlog.ReadById(100);
//dapperBlog.ReadById(4);
