using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleApp5.Models
{
    [Table("Tbl_Blogs")]
    internal class BlogModel
    {
        [Key]
        [Column("BlogId")]
        public int BlogId { get; set; }

        [Column("Title")]
        public string? Title { get; set; } = null!;

        [Column("Description")]
        public string? Description { get; set; } = string.Empty;

        [Column("AuthorName")]
        public string? AuthorName { get; set; }

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; } = false;
    }
}
