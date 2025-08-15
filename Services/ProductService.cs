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
            int totalCount = 10;
            int SizePg = totalCount * (page - 1);

            return new ProductList()
            {
                HasNext = false,
                TotalCount = totalCount,
                Products = _ctx.Products.Skip(SizePg).Take(totalCount).ToList()               
            };
        }

    }
}
