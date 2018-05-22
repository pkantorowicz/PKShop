using System;

namespace PKShop.Domain.Commands.Products
{
    public class CreateNewProductCommand : ProductCommand
    {
        public CreateNewProductCommand(string name, int quantity, decimal cost)
        {
            Name = name;
            Active = true;
            Quantity = quantity;
            Cost = cost;
        }
    }
}