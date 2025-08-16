using ProvaPub.Models;

namespace ProvaPub.Interface
{
    public interface IPaymentService
    {
        public Task<bool> PayOrder(Order order);
    }
}
