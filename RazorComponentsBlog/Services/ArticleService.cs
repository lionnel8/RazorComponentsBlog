using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorComponentsBlog.Models;
using Gobln.Pager;

namespace RazorComponentsBlog.Services
{
    public class ArticleService
    {
        private static string Title = "Sed convallis magna eu sem";
        private static string Text = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean fermentum risus id tortor. Cras pede libero, dapibus nec, pretium sit amet, tempor quis. Mauris dictum facilisis augue. In rutrum. Vivamus luctus egestas leo. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Pellentesque sapien. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas.";
        private static User User = new User { UserId = 1, FirstName = "Václav", LastName = "Novák", Email = "vaclav@novak.com" };
        private static readonly List<Article> Articles = new List<Article>()
        {
            new Article{ ArticleId=1, Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-1", User=User},
            new Article{ ArticleId=2, Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-2", User=User},
            new Article{ ArticleId=3, Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-3", User=User},
            new Article{ ArticleId=4, Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-4", User=User},
            new Article{ ArticleId=5, Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-5", User=User},
            new Article{ ArticleId=6, Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-6", User=User},
            new Article{ ArticleId=7, Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-7", User=User},
            new Article{ ArticleId=8, Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-8", User=User},
            new Article{ ArticleId=9, Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-9", User=User},
            new Article{ ArticleId=10, Created=DateTime.Now, Title=Title, Text=Text, Url="nadpis-clanku-10", User=User},
        };

        public Task<List<Article>> GetArticleList()
        {
            var pageList = Articles.ToPagedList();
            var page = pageList.ToPage(2, 6);
            
            return Task.FromResult(page.ToList());
        }

        public Task<Article> GetArticleDetail(int id, string url)
        {
            return Task.FromResult(Articles.Find(a => a.ArticleId.Equals(id) && a.Url.Equals(url)));
        }
    }
}
