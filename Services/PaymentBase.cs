using ProvaPub.Models;

namespace ProvaPub.Services
{
    public abstract class PaymentBase
    {
        public abstract Task<bool> PayOrder();

    }
}
