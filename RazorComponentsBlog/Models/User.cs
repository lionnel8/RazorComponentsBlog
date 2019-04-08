using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RazorComponentsBlog.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required] public string Email { get; set; }

        public string Password { get; set; }

        public string GoogleExternalId { get; set; }

        public string FacebookExternalId { get; set; }

        public List<Article> Articles { get; set; }
    }
}