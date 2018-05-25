using MediatR;
using PKShop.Domain.Events.Products;
using System.Threading;
using System.Threading.Tasks;

namespace PKShop.Domain.EventHandlers.Products
{
    public class ProductEventHandler :
        INotificationHandler<ProductCreatedEvent>,
        INotificationHandler<ProductUpdatedEvent>,
        INotificationHandler<ProductDeletedEvent>
    {
        public Task Handle(ProductCreatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ProductUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail

            return Task.CompletedTask;
        }

        public Task Handle(ProductDeletedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail

            return Task.CompletedTask;
        }
    }
}