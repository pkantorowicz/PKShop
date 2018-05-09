using System;

namespace PKShop.Domain.Commands.Products
{
    public class DeleteProductCommand : ProductCommand
    {
        public DeleteProductCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
    }
}