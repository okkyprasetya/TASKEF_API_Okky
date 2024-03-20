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
    public class CategoryData : ICategoryData
    {
        private readonly AppDbContext _context;

        public CategoryData(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int id)
        {
            var categoryToDelete = await _context.Categories.FindAsync(id);
            if (categoryToDelete != null)
            {
                _context.Categories.Remove(categoryToDelete);
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _context.Categories.OrderBy(c=> c.CategoryName).ToListAsync();
            return categories;
        }

        public async Task<Category> GetById(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == id);
            return category;
        }

        public async Task<IEnumerable<Category>> GetByName(string name)
        {
            var categories = await _context.Categories.OrderBy(c => c.CategoryName == name).ToListAsync();
            return categories;
        }

        public Task<int> GetCountCategories(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetWithPaging(int pageNumber, int pageSize, string name)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> Insert(Category entity)
        {
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task<int> InsertWithIdentity(Category category)
        {
            throw new NotImplementedException();
        }

        public async Task<Task> Update(Category entity)
        {
            _context.Categories.Update(entity);
            await _context.SaveChangesAsync();
            return Task.CompletedTask;
        }
    }
}
