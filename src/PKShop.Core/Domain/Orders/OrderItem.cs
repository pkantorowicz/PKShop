namespace PKShop.Core.Domain.Orders
{
    public class OrderItem
    {
        public ItemOrdered ItemOrdered { get; protected set; }
        public int Quantity { get; protected set; }
        public decimal Cost { get; protected set; }
    }
}
