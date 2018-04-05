using PKShop.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace PKShop.Core.Domain.Customers
{
    public class Customer : IAggregateRoot
    {
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

        public void ChangeEmail(string email)
        {
            if(Email != email)
            {
                Email = email;
            }
        }
    }
}
