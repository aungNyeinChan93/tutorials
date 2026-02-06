


using ConsoleApp7.DapperExample;

Console.WriteLine("Dapper ... ");

DapperBlog dapperBlog = new DapperBlog();

//dapperBlog.Read();
//dapperBlog.Create("test1","desc 1","author1");
//dapperBlog.Update(27, "uasdfa", "fasdfa", "kokok");
dapperBlog.Delete(27);