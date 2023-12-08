using Microsoft.EntityFrameworkCore;
using WebApiAngularProject.Data;
using WebApiAngularProject.Model;

namespace WebApiAngularProject.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext db;

        public ProductRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<int> AddProduct(Product product)
        {
            int result = 0;
            await db.Products.AddAsync(product);
            result = await db.SaveChangesAsync();
            return result;
        }

        public async Task<int> DeleteProduct(int id)
        {
            int result = 0;
            var product = await db.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            if (product != null)
            {
                db.Products.Remove(product);
                result = await db.SaveChangesAsync();
            }
            return result;
        }

        public async Task<Product> GetProductById(int id)
        {
            var product = await db.Products.Where(x => x.ProductId == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await db.Products.ToListAsync();
        }

        public async Task<int> UpdateProduct(Product product)
        {
            int result = 0;
            var b = await db.Products.Where(x => x.ProductId == product.ProductId).FirstOrDefaultAsync();
            if (b != null)
            {
                b.Productname = product.Productname;
                b.Productprice = product.Productprice;
                b.CategoryId = product.CategoryId;
                b.imageUrl = product.imageUrl;

                result = await db.SaveChangesAsync();
            }
            return result;
        }
    }
}
