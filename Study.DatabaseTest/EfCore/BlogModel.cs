using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.DatabaseTest.EfCore
{
    public class BlogModel
    {
        [Key]
        public int BlogId { get; set; }

        [MaxLength(2000)]
        public string? Url { get; set; }

        public List<PostModel> Posts { get; set; } = new List<PostModel>();
    }
}
