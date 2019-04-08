using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorComponentsBlog.Models
{
    public class Article
    {
        public int ArticleId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Created { get; set; }

        [Required] public string Title { get; set; }

        public string Text { get; set; }

        [Required] public string Url { get; set; }

        public string Image { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}