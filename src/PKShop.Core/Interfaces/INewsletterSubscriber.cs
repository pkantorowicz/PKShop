using PKShop.Core.Domain.Customers;

namespace PKShop.Core.Interfaces
{
    public interface INewsletterSubscriber
    {
        void Subscribe(Customer customer);
    }
}
