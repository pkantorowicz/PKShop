using System;
using System.Threading.Tasks;
using MediatR;
using PKShop.Core.Bus;
using PKShop.Core.Notifications;
using PKShop.Domain.Commands.Products;
using PKShop.Domain.DomainClasses.Products;
using PKShop.Domain.Events.Products;
using PKShop.Domain.Interfaces;

namespace PKShop.Domain.CommandHandlers
{
    public class ProductCommandHandler : CommandHandler,
        INotificationHandler<CreateNewProductCommand>,
        INotificationHandler<UpdateProductCommand>,
        INotificationHandler<DeleteProductCommand>
        {
            private readonly IProductRepository _productRepository;
            private readonly IMediatrHandler _bus;

            public ProductCommandHandler(IProductRepository productRepository, IMediatrHandler bus,
                IUnitOfWork unitOfWork, INotificationHandler<DomainNotification> notification) :
                base(uow, bus, notification)
            {
                _productRepository = productRepository;
                _bus = bus;
            }

            public async Task HandleAsync(CreateNewProductCommand command)
            {
                var product = new Product(Guid.NewGuid(), command.Name, command.Quantity, command.Cost);

                if (await _productRepository.GetAsync(product.Id) != null)
                {
                    await _bus.RaiseEvent(new DomainNotification(command.MessageType, "Product with this email already exists."));
                    return;
                }

                await _productRepository.CreateAsync(product);

                if(Commit())
                {
                    await _bus.RaiseEvent(new ProductCreatedEvent(product.Id, product.Name, product.Quantity, product.Cost));
                }
            }
        }
}