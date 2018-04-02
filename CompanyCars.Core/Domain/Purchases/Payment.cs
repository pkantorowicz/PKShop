using CompanyCars.Core.Domain.Orders;
using CompanyCars.Core.Exceptions;
using CompanyCars.Core.Interfaces;
using System;

namespace CompanyCars.Core.Domain.Purchases
{
    public class Payment : BaseEntity, IAggregateRoot
    {
        public int OrderId { get; protected set; }
        public PaymentType PaymentType { get; protected set; }
        public PaymentMethod PaymentMethod { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public Order Amount { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreateAt { get; protected set; }

        protected Payment()
        {
        }

        public Payment(int orderId, PaymentType paymentType, PaymentMethod paymentMethod, string title,
            string decription, decimal value)
        {
            OrderId = orderId;
            SetPaymentType(paymentType);
            SetPaymentMethod(paymentMethod);
            SetTitle(title);
            Description = decription;
            CreateAt = DateTime.UtcNow;
        }

        public void SetPaymentType(PaymentType paymentType)
        {
            PaymentType = paymentType;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPaymentMethod(PaymentMethod paymentMethod)
        {
            PaymentMethod = paymentMethod;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new CompanyCarsException($"Title cannot be empty");
            }

            Title = title;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
