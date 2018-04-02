namespace CompanyCars.Core.Domain.Purchases
{
    public class PaymentType : BaseEntity
    {
        public string Type { get; protected set; }

        protected PaymentType()
        {
        }

        public PaymentType(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
