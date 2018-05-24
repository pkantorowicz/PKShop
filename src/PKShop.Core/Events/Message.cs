using System;
using MediatR;

namespace PKShop.Core.Events
{
    public class Message : IRequest
    {
        public string MessageType { get; protected set; }
        public Guid AggregateId { get; protected set; }

        public Message()
        {
            MessageType = GetType().Name;
        }
    }
}