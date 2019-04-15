using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorComponentsBlog.Models;

namespace RazorComponentsBlog.Data
{
    public class DbInitializer
    {

        public static void Initialize(RazorComponentsBlogDbContext db)
        {
            db.Database.EnsureCreated();

            if (db.Articles.Any())
            {
                return;
            }
            User user = new User { FirstName = "Jan", LastName = "Budař", Email = "honza.budar@gmail.com" };
            db.Users.Add(user);
            db.SaveChanges();

            List<Category> categories = new List<Category>
                {
                    new Category {Name = "Razor Components"},
                    new Category {Name = "Blazor"},
                    new Category {Name = "ASP.NET Core"},
                    new Category {Name = ".NET Core"},
                };
            foreach (Category category in categories)
            {
                db.Categories.Add(category);
            }
            db.SaveChanges();

            string title = "Sed convallis magna eu sem";
            string text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean fermentum risus id tortor. Cras pede libero, dapibus nec, pretium sit amet, tempor quis. Mauris dictum facilisis augue. In rutrum. Vivamus luctus egestas leo. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Pellentesque sapien. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.";
            List<Article> articles = new List<Article>()
            {
                new Article{ Created=DateTime.Now, Title=title, Text=text, Url="nadpis-clanku-1", User=user},
                new Article{ Created=DateTime.Now, Title=title, Text=text, Url="nadpis-clanku-2", User=user},
                new Article{ Created=DateTime.Now, Title=title, Text=text, Url="nadpis-clanku-3", User=user},
                new Article{ Created=DateTime.Now, Title=title, Text=text, Url="nadpis-clanku-4", User=user},
                new Article{ Created=DateTime.Now, Title=title, Text=text, Url="nadpis-clanku-5", User=user},
                new Article{ Created=DateTime.Now, Title=title, Text=text, Url="nadpis-clanku-6", User=user},
                new Article{ Created=DateTime.Now, Title=title, Text=text, Url="nadpis-clanku-7", User=user},
                new Article{ Created=DateTime.Now, Title=title, Text=text, Url="nadpis-clanku-8", User=user},
                new Article{ Created=DateTime.Now, Title=title, Text=text, Url="nadpis-clanku-9", User=user},
                new Article{ Created=DateTime.Now, Title=title, Text=text, Url="nadpis-clanku-10", User=user},
            };

            foreach (Article article in articles)
            {
                db.Articles.Add(article);
            }

            db.SaveChanges();
        }
    }
}
