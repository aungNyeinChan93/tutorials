using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7.DapperDto
{
    internal class BlogDto
    {
        public int BlogId { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string AuthorName { get; set; } = null!;

        public int DeleteFlag { get; set; } = 0;
    }
}
