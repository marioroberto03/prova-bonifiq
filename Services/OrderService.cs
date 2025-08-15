using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
	public class OrderService
	{
        TestDbContext _ctx;

        public OrderService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Order> PayOrder(PaymentBase payment, decimal paymentValue, int customerId)
		{
            await payment.PayOrder();
            
            DateTime dtNow = DateTime.Now;
            DateTime dtOrder = new DateTime(dtNow.Year, dtNow.Month, dtNow.Day, dtNow.Hour, dtNow.Minute, dtNow.Second, DateTimeKind.Utc);

            var order  = await InsertOrder(new Order() //Retorna o pedido para o controller
            {
                CustomerId = customerId,
                Value = paymentValue,
                OrderDate = DateTime.Now,
            });

            order.OrderDate = order.OrderDate.AddHours(-3);  //Retorna a data em UTC-3
            return order;
		}

        public async Task<Order> InsertOrder(Order order)
        {
			//Insere pedido no banco de dados
			return (await _ctx.Orders.AddAsync(order)).Entity;
        }
	}
}
