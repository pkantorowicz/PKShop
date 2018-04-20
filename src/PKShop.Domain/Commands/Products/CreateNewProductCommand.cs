using System;

namespace PKShop.Domain.Commands.Products
{
    public class CreateNewProductCommand : ProductCommand
    {
        public CreateNewProductCommand(Guid id, string name, int quantity, decimal cost)
        {
            Id = id;
            Name = name;
            Active = true;
            Quantity = quantity;
            Cost = cost;
        }
    }
}