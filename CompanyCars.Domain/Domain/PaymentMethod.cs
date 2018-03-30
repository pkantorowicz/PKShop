namespace CompanyCars.Core.Domain
{
    public class PaymentMethod : BaseEntity
    {
        public string Method { get; protected set; }

        protected PaymentMethod()
        {
        }

        public PaymentMethod(int id, string method)
        {
            Id = Id;
            Method = method;
        }
    }
}
