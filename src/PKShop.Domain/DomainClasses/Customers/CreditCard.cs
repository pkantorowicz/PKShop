using System;
using System.Linq;
using PKShop.Domain.Exceptions;

namespace PKShop.Domain.DomainClasses.Customers
{
    public class CreditCard
    {
        public Guid Id { get; protected set; }
        public string NameOnCard { get; protected set; }
        public string CardNumber { get; protected set; }
        public bool Active { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime Expiry { get; protected set; }
        public Customer Customer { get; protected set; }

        protected CreditCard()
        {
        }

        public CreditCard(string nameOnCard, string cardNumber, bool active,
            DateTime expiry, Customer customer)
        {
            SetNameOfCard(nameOnCard);
            SetCardNumber(cardNumber);
            IsExpired(expiry, active);
            Customer = customer;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetNameOfCard(string nameOfCard)
        {
            if (string.IsNullOrEmpty(nameOfCard))
            {
                throw new PKShopException(Codes.InvalidNameOnCard,
                    "Name of card can not be empty.");
            }
            if (nameOfCard.Length > 50)
            {
                throw new PKShopException(Codes.InvalidNameOnCard,
                    "Name of card can not be longer than 50 characters.");
            }

            NameOnCard = nameOfCard;
        }

        public void SetCardNumber(string cardNumber)
        {
            if (string.IsNullOrEmpty(cardNumber))
            {
                throw new PKShopException(Codes.InvalidCardNumber,
                    "Card number can not be empty.");
            }

            CardNumber = cardNumber;
        }

        public void IsExpired(DateTime expiry, bool active)
        {
            if (expiry < DateTime.UtcNow)
            {
                active = false;

                throw new PKShopException(Codes.CardExpired,
                    "This card was expired.");
            }
            active = true;

            Expiry = expiry;
            Active = active;
        }
        
        public static CreditCard Create(string nameOnCard, string cardNumber, DateTime expiry,
            bool active, Customer customer)
        {
            var creditCard = new CreditCard(nameOnCard, cardNumber, active, expiry, customer);

            if (customer.CreditCards.Contains(creditCard))
            {
                throw new PKShopException(Codes.CreditCardAlreadyExists,
                    "Credit card already exsists for this customer.");
            }
            return creditCard;
        }
    }
}
