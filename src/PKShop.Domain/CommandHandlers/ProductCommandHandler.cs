using System;
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
            private readonly IMediatorHandler _bus;

            public ProductCommandHandler(IProductRepository productRepository, IMediatorHandler bus,
                IUnitOfWork uow, INotificationHandler<DomainNotification> notification) :
                base(uow, bus, notification)
            {
                _productRepository = productRepository;
                _bus = bus;
            }

            public void Handle(CreateNewProductCommand command)
            {
                var product = new Product(Guid.NewGuid(), command.Name, command.Quantity, command.Cost);
                var productFromDb = _productRepository.Get(product.Id);

                if (productFromDb != null)
                {
                    _bus.RaiseEvent(new DomainNotification(command.MessageType, "Product with this email already exists."));
                    return;
                }
                _productRepository.Create(product);

                if(Commit())
                {
                    _bus.RaiseEvent(new ProductCreatedEvent(product.Id, product.Name, product.Quantity, product.Cost));
                }
            }

            public void Handle(UpdateProductCommand command)
            {
                var product = new Product(Guid.NewGuid(), command.Name, command.Quantity, command.Cost);
                var existingProduct = _productRepository.Get(product.Id);

                if (existingProduct != null)
                {
                    if (existingProduct.Equals(product))
                    {
                        _bus.RaiseEvent(new DomainNotification(command.MessageType, "This product already exists in shop."));
                        return;
                    }
                }
                _productRepository.Update(product);

                if (Commit())
                {
                   _bus.RaiseEvent(new ProductUpdatedEvent(product.Id, product.Name, product.Quantity, product.Cost));
                }
            }

            public void Handle(DeleteProductCommand command)
            {
                _productRepository.Delete(command.Id);

                if (Commit())
                {
                    _bus.RaiseEvent(new ProductCodeDeletedEvent(command.Id));
                }
            }
        }
}