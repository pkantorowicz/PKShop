using PKShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PKShop.Core.Domain.Carts
{
    public class Cart : IAggregateRoot
    {
        public List<CartItem> _cartItems = new List<CartItem>();

        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public IEnumerable<CartItem> CartItems => _cartItems.AsReadOnly();
        public decimal TotalCost => CartItems.Sum(x => x.TotalCost);
        public decimal TotalTax => CartItems.Sum(x => x.Tax);

        protected Cart()
        {
        }


    }
}
