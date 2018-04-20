using MediatR;
using PKShop.Domain.Events.Products;

namespace PKShop.Domain.EventHandlers.Products
{
    public class ProductEventHandler :
        INotificationHandler<ProductCreatedEvent>,
        INotificationHandler<ProductUpdatedEvent>,
        INotificationHandler<ProductDeletedEvent>
    {
        public void Handle(ProductCreatedEvent message)
        {
            //todo
        }

        public void Handle(ProductUpdatedEvent message)
        {
            //todo
        }

        public void Handle(ProductDeletedEvent message)
        {
            //todo
        }
    }
}
