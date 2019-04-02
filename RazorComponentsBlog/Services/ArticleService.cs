using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorComponentsBlog.Models;

namespace RazorComponentsBlog.Services
{
    public class ArticleService
    {
        private static User User = new User { UserId = 1, FirstName = "Václav", LastName = "Novák", Email = "vaclav@novak.com" };
        private static readonly List<Article> Articles = new List<Article>()
        {
            new Article{ ArticleId=1, Created=new DateTime(), Title="Nadpis článku 1", Text="Text článku 1", Url="nadpis-clanku-1", User=User},
            new Article{ ArticleId=2, Created=new DateTime(), Title="Nadpis článku 2", Text="Text článku 2", Url="nadpis-clanku-2", User=User},
            new Article{ ArticleId=3, Created=new DateTime(), Title="Nadpis článku 3", Text="Text článku 3", Url="nadpis-clanku-3", User=User},
            new Article{ ArticleId=4, Created=new DateTime(), Title="Nadpis článku 4", Text="Text článku 4", Url="nadpis-clanku-4", User=User},
            new Article{ ArticleId=5, Created=new DateTime(), Title="Nadpis článku 5", Text="Text článku 5", Url="nadpis-clanku-5", User=User},
            new Article{ ArticleId=6, Created=new DateTime(), Title="Nadpis článku 6", Text="Text článku 6", Url="nadpis-clanku-6", User=User},
        };

        public Task<List<Article>> GetArticleList()
        {
            return Task.FromResult(Articles);
        }

        public Task<Article> GetArticleDetail(int id, string url)
        {
            return Task.FromResult(Articles.Find(a => a.ArticleId.Equals(id) && a.Url.Equals(url)));
        }
    }
}
