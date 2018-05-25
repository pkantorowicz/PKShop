using System;

namespace PKShop.Struct.Services.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
    }
}