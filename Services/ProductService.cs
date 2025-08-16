using ProvaPub.Extensions;
using ProvaPub.Models;
using ProvaPub.Repository;
using System.Linq;

namespace ProvaPub.Services
{
    public class ProductService
    {
        TestDbContext _ctx;

        public ProductService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public ProductList ListProducts(int page)
        {
            return new ProductList()
            {
                Products = _ctx.Products.AsQueryable().ToPagedResultAsync(page).Result.Items,
            };
        }

    }
}
