using PKShop.Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using System;
using PKShop.Core.Interfaces;

namespace PKShop.Core.Domain.Identity
{
    class RefreshToken : IAggregateRoot
    {
        public Guid Id { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Token { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime? RevokedAt { get; protected set; }
        public bool Revoked => RevokedAt.HasValue;

        public RefreshToken()
        {
        }

        public RefreshToken(User user, IPasswordHasher<User> passwordHasher)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            CreatedAt = DateTime.UtcNow;
            Token = CreateToken(user, passwordHasher);
        }

        public void Revoke()
        {
            if (Revoked)
            {
                throw new PKShopException($"Refresh token: '{Id}' was already revoked at '{RevokedAt}'.");
            }
            RevokedAt = DateTime.UtcNow;
        }

        private static string CreateToken(User user, IPasswordHasher<User> passwordHasher)
          => passwordHasher.HashPassword(user, Guid.NewGuid().ToString("N"))
              .Replace("=", string.Empty)
              .Replace("+", string.Empty)
              .Replace("/", string.Empty);
    }
}
