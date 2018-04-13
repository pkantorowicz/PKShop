using PKShop.Core.Domain.Identity;
using PKShop.Core.Exceptions;
using PKShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PKShop.Core.Domain.Customers
{
    public class Customer : IAggregateRoot
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        private List<CreditCard> _creditCards = new List<CreditCard>();

        public Guid Id { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Email { get; set; }
        public string CompanyName { get; protected set; }
        public decimal Balance { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public IEnumerable<CreditCard> CreditCards => _creditCards.AsReadOnly();

        protected Customer()
        {
        }

        public Customer(Guid id, string firstname, string lastName, string email,
            string companyName, decimal balance)
        {
            Id = id;
            SetFirstName(firstname);
            SetLastName(lastName);
            SetEmail(email);
            SetCompanyName(companyName);
            SetBalance(balance);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetFirstName(string firstName)
        {
            if (String.IsNullOrEmpty(firstName))
            {
                throw new PKShopException(ErrorCodes.InvalidFirstName,
                    "Firstname is invalid.");
            }
            if (firstName.Length > 50)
            {
                throw new PKShopException(ErrorCodes.InvalidFirstName,
                    "Firstname cannot be longer than 50 characters");
            }

            FirstName = firstName.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetLastName(string lastName)
        {
            if (String.IsNullOrEmpty(lastName))
            {
                throw new PKShopException(ErrorCodes.InvalidLastName,
                    "LastName is invalid.");
            }
            if (lastName.Length > 50)
            {
                throw new PKShopException(ErrorCodes.InvalidLastName,
                    "LastName cannot be longer than 50 characters");
            }

            LastName = lastName.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new PKShopException(ErrorCodes.InvalidEmail,
                    "Email can not be empty.");
            }
            if (!EmailRegex.IsMatch(email) || !email.Contains("@"))
            {
                throw new PKShopException(ErrorCodes.InvalidEmail,
                    $"Invalid email: '{email}'.");
            }
            if (Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetCompanyName(string companyName)
        {
            if (String.IsNullOrEmpty(companyName))
            {
                throw new PKShopException(ErrorCodes.InvalidCompanyName,
                    "CompanyName is invalid.");
            }
            if (companyName.Length > 100)
            {
                throw new PKShopException(ErrorCodes.InvalidCompanyName,
                    "CompanyName cannot be longer than 100 characters");
            }

            CompanyName = companyName.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetBalance(decimal balance)
        {
            if (balance < 0)
            {
                throw new PKShopException(ErrorCodes.InvalidBalance,
                    "Balance can not be smaller than 0.");
            }
            if (Balance == balance)
            {
                return;
            }

            Balance = balance;
            UpdatedAt = DateTime.UtcNow;
        }

        public void AddCreditCard(string nameOnCard, string cardNumber, bool active, DateTime expiry, Customer customer)
        {
            var card = CreditCards.SingleOrDefault(x => x.CardNumber == cardNumber);
            if (card != null)
            {
                throw new PKShopException(ErrorCodes.CreditCardAlreadyExists,
                    $"Card with this number: {cardNumber} already exists.");
            }
            _creditCards.Add(CreditCard.Create(nameOnCard, cardNumber, expiry, active, customer));
            UpdatedAt = DateTime.UtcNow;
        }

        public void RemoveCreditCard(string cardNumber)
        {
            var card = CreditCards.SingleOrDefault(x => x.CardNumber == cardNumber);
            if (card == null)
            {
                throw new PKShopException(ErrorCodes.CreditCardNotFound,
                    $"Credit card with number: {cardNumber} for customer: {FirstName} was not found.");
            }
            _creditCards.Remove(card);
            UpdatedAt = DateTime.UtcNow;
        }

        public static Customer Create(Guid id, string firstname, string lastName, string email,
            string companyName, decimal balance)
            => new Customer(id, firstname, lastName, email, companyName, balance);
    }
}
