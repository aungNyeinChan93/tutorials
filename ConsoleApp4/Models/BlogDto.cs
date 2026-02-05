using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Models
{
    internal class BlogDto
    {
        public int? BlogId { get; set; }

        public string? Title { get; set; } = string.Empty;

        public string? Description { get; set; } = null!;

        public string? AuthorName { get; set; } = null!;

        public int DeleteFlag { get; set; }

    }
}
