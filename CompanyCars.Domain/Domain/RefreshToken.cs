using System;

namespace CompanyCars.Core.Domain
{
    class RefreshToken : BaseEntity
    {
        public Guid TokenId { get; protected set; }
        public int UserId { get; protected set; }
        public User User { get; protected set; }
        public string Token { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? RevokedAt { get; protected set; }
        public bool Revoked => RevokedAt.HasValue;
    }
}
