using BlogAppApi.Data;
using BlogAppApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAppApi.Repositories.CategoryRepository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            var categories =await _context.Categories.ToListAsync();
            return categories;
        }
        public async Task<Category> GetCategoryById(int id)
        {
            var category= await _context.Categories.FindAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with id {id} not found.");
            }
            return category;
        }
        public async Task UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }
    }
    
}
