using ProvaPub.Interface;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class OrderService
	{
        TestDbContext _ctx;
        IPaymentService _Payment;

        public OrderService(TestDbContext ctx, IPaymentService payment)
        {
            _ctx = ctx;
            _Payment = payment;
        }

        public async Task<Order> PayOrder(Order order)
		{
            if (await _Payment.PayOrder(order))
            {
                order.OrderDate = DateTime.UtcNow;

                await InsertOrder(order);

                order.OrderDate = order.OrderDate.AddHours(-3);
            }

            return order;
		}

        public async Task<Order> InsertOrder(Order order)
        {
            var entity = (await _ctx.Orders.AddAsync(order)).Entity;
            await _ctx.SaveChangesAsync();
            return entity;
        }
	}
}
