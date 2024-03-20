using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore;
using MyRESTServices.Data.Interfaces;
using MyRESTServices.Domain;
using MyRESTServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRESTServices.Data
{
    public class ArticleData : IArticleData
    {
        private readonly AppDbContext _context;

        public ArticleData(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Delete(int id)
        {
            var articleToDelete = await _context.Articles.FindAsync(id);
            if (articleToDelete != null)
            {
                _context.Articles.Remove(articleToDelete);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            var articles = await _context.Articles.OrderBy(a => a.ArticleId).ToListAsync();
            return articles;
        }

        public async Task<IEnumerable<Article>> GetArticleByCategory(int categoryId)
        {
            var articles = await _context.Articles
                            .Where(a => a.CategoryId == categoryId)
                            .ToListAsync();

            return articles;
        }

        public async Task<IEnumerable<Article>> GetArticleWithCategory()
        {
            var articles = await _context.Articles
                .Include(a => a.Category) // Include the Category navigation property
                .ToListAsync();

            return articles;
        }

        public async Task<Article> GetById(int id)
        {
            var article = await _context.Articles.FirstOrDefaultAsync(a => a.ArticleId == id);
            return article;
        }

        public Task<int> GetCountArticles()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Article>> GetWithPaging(int categoryId, int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> Insert(Article entity)
        {
            _context.Articles.Add(entity);
            await _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task<Task> InsertArticleWithCategory(Article article)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertWithIdentity(Article article)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> Update(Article entity)
        {
            _context.Articles.Update(entity);
            await _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
