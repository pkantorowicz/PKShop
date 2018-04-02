using CompanyCars.Core.Domain.Orders;
using CompanyCars.Core.Exceptions;
using CompanyCars.Core.Interfaces;
using System;

namespace CompanyCars.Core.Domain.Purchases
{
    public class Payment : BaseEntity, IAggregateRoot
    {
        public int OrderId { get; protected set; }
        public string PaymentType { get; protected set; }
        public PaymentType Type { get; protected set; }
        public string PaymentMethod { get; protected set; }
        public PaymentMethod Method { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public decimal Value { get; protected set; }
        public Order Order { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreateAt { get; protected set; }

        protected Payment()
        {
        }

        public Payment(int orderId, string paymentType, string paymentMethod, string title,
            string decription, decimal value)
        {
            OrderId = orderId;
            SetPaymentType(paymentType);
            SetPaymentMethod(paymentMethod);
            SetTitle(title);
            Description = decription;
            CreateAt = DateTime.UtcNow;
        }

        public void SetPaymentType(string paymentType)
        {
            if (string.IsNullOrEmpty(paymentType))
            {
                throw new CompanyCarsException($"Type cannot be empty");
            }

            PaymentType = paymentType;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPaymentMethod(string paymentMethod)
        {
            if (string.IsNullOrEmpty(paymentMethod))
            {
                throw new CompanyCarsException($"Method cannot be empty");
            }

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
