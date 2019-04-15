using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorComponentsBlog.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Article> Articles { get; set; }
    }
}
