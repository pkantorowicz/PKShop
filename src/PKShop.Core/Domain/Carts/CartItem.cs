using System;
using PKShop.Core.Domain.Products;

namespace PKShop.Core.Domain.Carts
{
    public class CartItem
    {
        public Guid CartId { get; protected set; }
        public int Quantity { get; protected set; }
        public Guid ProductId { get; protected set; }
        public string ProductName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public decimal Cost { get; protected set; }
        public decimal TotalCost => Quantity * Cost;
        public decimal Tax { get; set; }

        protected CartItem()
        {         
        }

        public CartItem(Product product, Cart cart, int quantity)
        {
            CartId = cart.Id;
            ProductId = product.Id;
            ProductName = product.Name;
            Cost = product.Cost;
            Quantity = quantity;           
        }

        public void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }

        public static CartItem Create(Product product, Cart cart, int quantity)
            => new CartItem(product, cart, quantity);

    }
}
