using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gobln.Pager;
using Microsoft.EntityFrameworkCore;
using RazorComponentsBlog.Data;
using RazorComponentsBlog.Models;

namespace RazorComponentsBlog.Services
{
    public class ArticleService
    {
        private readonly RazorComponentsBlogDbContext db;

        public ArticleService(RazorComponentsBlogDbContext db)
        {
            this.db = db;
        }

        public async Task<PagedList<Article>> GetPagedArticles()
        {
            return await db.Articles.OrderByDescending(a => a.Created).ToPagedListAsync();
        }


        public async Task<List<Article>> GetArticles()
        {
            return await db.Articles.OrderByDescending(a => a.Created).ToListAsync();
        }

        public async Task<List<Article>> GetArticles(string searchString)
        {
            return await db.Articles.Where(a => a.Text.Contains(searchString) || a.Title.Contains(searchString))
                .OrderByDescending(a => a.Created).ToListAsync();
        }

        public async Task<Article> GetArticleDetail(int id, string url)
        {
            return await db.Articles.FirstOrDefaultAsync(a => a.ArticleId.Equals(id) && a.Url.Equals(url));
        }

        public async Task AddArticle(Article article)
        {
            db.Articles.Add(article);
            await db.SaveChangesAsync();
        }

        public async Task UpdateArticle(Article article)
        {
            db.Entry(article).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task DeleteArticle(int id)
        {
            var article = await db.Articles.FindAsync(id);
            db.Articles.Remove(article);
            await db.SaveChangesAsync();
        }
    }
}