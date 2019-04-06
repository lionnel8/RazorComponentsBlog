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
            User User = new User { FirstName = "Václav", LastName = "Novák", Email = "vaclav@novak.com" };
            db.Users.Add(User);
            db.SaveChanges();

            string Title = "Sed convallis magna eu sem";
            string Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean fermentum risus id tortor. Cras pede libero, dapibus nec, pretium sit amet, tempor quis. Mauris dictum facilisis augue. In rutrum. Vivamus luctus egestas leo. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Pellentesque sapien. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.";
            List<Article> Articles = new List<Article>()
        {
            new Article{ Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-1", User=User},
            new Article{ Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-2", User=User},
            new Article{ Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-3", User=User},
            new Article{ Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-4", User=User},
            new Article{ Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-5", User=User},
            new Article{ Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-6", User=User},
            new Article{ Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-7", User=User},
            new Article{ Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-8", User=User},
            new Article{ Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-9", User=User},
            new Article{ Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-10", User=User},
        };

            foreach (Article article in Articles)
            {
                db.Articles.Add(article);
            }

            db.SaveChanges();
        }
    }
}
