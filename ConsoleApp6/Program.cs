


using ConsoleApp6.EFCoreExample;

Console.WriteLine("EF Core  ... ");

BlogCRUD blog =  new BlogCRUD();

//blog.Read();
//blog.Create("Test Title EF core","Test Desc ","DODO");
//blog.Update(id:26,title:"test",desc:"test desc",author:"nono");
//blog.Update(id: 26, author: "popo");
blog.Delete(id: 26);