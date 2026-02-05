

using ConsoleApp5.EFCore;

Console.WriteLine("Ef Core ...");

BlogsExample blogEg = new BlogsExample();

//blogEg.Read();
//blogEg.Create("Test title by EF","Tes Desc by ef","chan");
//blogEg.ReadById(222);
//blogEg.ReadById(2);
//blogEg.Update(1111,"Update by ef","Update desc by ef","aung");
//blogEg.Update(1, "Update by efdffff","Update desc by ef","aung");
blogEg.Delete(24);