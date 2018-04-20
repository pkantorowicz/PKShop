using System;

namespace PKShop.Domain.Commands.Products
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(Guid id, string name, int quantity, decimal cost)
        {
            Id = id;
            Name = name;
            Active = true;
            Quantity = quantity;
            Cost = cost;
        }
    }
}