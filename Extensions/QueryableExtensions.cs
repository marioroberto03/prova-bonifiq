using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;

namespace ProvaPub.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(
            this IQueryable<T> query, int page, int pageSize = 10)
            where T : class
        {
            if (page <= 0) page = 1;

            int totalCount = await query.CountAsync();
            int skip = (page - 1) * pageSize;

            var items = await query.Skip(skip).Take(pageSize).ToListAsync();

            return new PagedResult<T>
            {
                HasNext = skip + pageSize < totalCount,
                TotalCount = totalCount,
                Items = items
            };
        }
    }
}
