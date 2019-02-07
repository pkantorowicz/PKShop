using PKShop.Core.Types;
using PKShop.Domain.DomainClasses.Customers;
using PKShop.Domain.Exceptions.DomainExceptions;
using System;

namespace PKShop.Domain.DomainClasses.Products
{
    public class Return : EntityBase, ITimestampable
    {
        public Product Product { get; protected set; }
        public Customer Customer { get; protected set; }
        public ReturnReason Reason { get; protected set; }
        public string Note { get; protected set; }

        public Return(Guid id, Product product, Customer customer, ReturnReason reason, string note)
        {
            Id = id;
            SetProduct(product);
            SetCustomer(customer);
            Reason = reason;
            SetNote(note);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetProduct(Product product)
        {
            Product = product ?? throw new ReturnException(Codes.ProductNotProvided,
                  "Product not provided!");

            SetUpdatedDate();
        }

        public void SetCustomer(Customer customer)
        {
            Customer = customer ?? throw new ReturnException(Codes.CustomerNotProvided,
                  "Customer not provided!");

            SetUpdatedDate();
        }

        public void SetNote(string note)
        {
            if (string.IsNullOrEmpty(note))
            {
                throw new ReturnException(Codes.NoteEmptyOrNotProvided,
                    "Note can not be empty!");
            }

            if (note.Length > 1000)
            {
                throw new ReturnException(Codes.InvalidNote,
                    "Note is too long.");
            }

            Note = note;
            SetUpdatedDate();
        }
    }
}
