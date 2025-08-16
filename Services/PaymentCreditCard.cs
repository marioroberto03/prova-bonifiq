
using ProvaPub.Interface;
using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class PaymentCreditCard : IPaymentService
    {
        public Task<bool> PayOrder(Order order)
        {
            return Task.FromResult(true);
        }
    }
}
