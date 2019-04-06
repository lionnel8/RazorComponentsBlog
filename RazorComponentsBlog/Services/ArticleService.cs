using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorComponentsBlog.Models;
using Gobln.Pager;
using Microsoft.EntityFrameworkCore;
using RazorComponentsBlog.Data;

namespace RazorComponentsBlog.Services
{
    public class ArticleService
    {
        private readonly RazorComponentsBlogDbContext db;

        public ArticleService(RazorComponentsBlogDbContext db)
        {
            this.db = db;
        }

        //public Task<List<Article>> GetArticleList()
        //{
        //    var pageList = Articles.ToPagedList();
        //    var page = pageList.ToPage(2, 6);

        //    return Task.FromResult(page.ToList());
        //}
        public async Task<List<Article>> GetArticles()
        {
            return await db.Articles.ToListAsync();
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
            Article article = await db.Articles.FindAsync(id);
            db.Articles.Remove(article);
            await db.SaveChangesAsync();
        }

    }
}
