using PKShop.Domain.DomainClasses.Identity;
using PKShop.Domain.DomainClasses.Products;
using PKShop.Domain.DomainClasses.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PKShop.Domain.DomainClasses.Carts
{
    public class Cart : EntityBase
    {
        public List<CartItem> _cartItems = new List<CartItem>();

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<CartItem> CartItems => _cartItems.AsReadOnly();
        public decimal TotalCost => CartItems.Sum(x => x.TotalCost);
        public decimal TotalTax => CartItems.Sum(x => x.Tax);
        public DateTime CreatedAt { get; set; }

        protected Cart()
        {
        }

        public Cart(User user)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            CreatedAt = DateTime.UtcNow;
        }

        public void Clear()
            => _cartItems.Clear();

        public void AddCartItem(Product product, Cart cart, int quantity)
        {
            var item = GetCartItem(product.Id);
            if (product != null)
            {
                item.IncreaseQuantity(quantity);
                return;
            }
            item = new CartItem(product, cart, quantity);
            _cartItems.Add(item);
        }

        public void RemoveItem(Guid productId)
        {
            var item = GetCartItem(productId);
            if (item == null)
            {
                return;
            }
            _cartItems.Remove(item);
        }

        private CartItem GetCartItem(Guid productId)
            => _cartItems.SingleOrDefault(x => x.ProductId == productId);

        public static Cart Create(User user)
            => new Cart(user);
    }
}
