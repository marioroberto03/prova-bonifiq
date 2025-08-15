using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class RandomService
	{
		int seed;
        TestDbContext _ctx;
		public RandomService()
        {
            var contextOptions = new DbContextOptionsBuilder<TestDbContext>()
    .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Teste;Trusted_Connection=True;")
    .Options;
            seed = Guid.NewGuid().GetHashCode();

            _ctx = new TestDbContext(contextOptions);
        }
        public async Task<int> GetRandom()
		{
            var number =  new Random().Next(1, 100);            
            
            var NumeroExistente = _ctx.Numbers.FirstOrDefault(it => it.Number == number);
            if (NumeroExistente != null)
            {                
                return await this.GetRandom();
            }
            else
            {
                return this.Save(number);
            }
		}

        public int Save(int number)
        {
            _ctx.Numbers.Add(new RandomNumber() { Number = number });
            _ctx.SaveChanges();
            return number;
        }
    }
}
