using Microsoft.EntityFrameworkCore;
using WebApiAngularProject.Data;
using WebApiAngularProject.Model;

namespace WebApiAngularProject.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext db;

        public CategoryRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<int> AddCategory(Category category)
        {
            int result = 0;
            await db.Categories.AddAsync(category);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteCategory(int id)
        {
            int result = 0;
            var category = await db.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
            if (category != null)
            {
                db.Categories.Remove(category);
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await db.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            var category = await db.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<int> UpdateCategory(Category category)
        {
            int result = 0;
            var b = await db.Categories.Where(x => x.CategoryId == category.CategoryId).FirstOrDefaultAsync();
            if (b != null)
            {
                b.CategoryName = category.CategoryName;
               
                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
