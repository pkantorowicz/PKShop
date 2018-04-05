using PKShop.Core.Exceptions;
using PKShop.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text.RegularExpressions;

namespace PKShop.Core.Domain.Identity
{
    public class User : IAggregateRoot
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public Guid Id { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public string Role { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public User() 
        {
        }

        public User(Guid id, string username, string email, string fullName, string role)
        {
            Id = id;
            SetUsername(username);
            SetFullName(fullName);
            SetEmail(email);
            SetRole(role);
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                throw new PKShopException(ErrorCodes.InvalidName, 
                    "Username is invalid.");
            }
            if (username.Length > 50)
            {
                throw new PKShopException(ErrorCodes.InvalidName, 
                    "Usename cannot be longer than 50 characters");
            }

            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetFullName(string fullName)
        {
            if (fullName.Length > 100)
            {
                throw new PKShopException(ErrorCodes.InvalidFullName,
                    "Fullname cannot be longer than 100 characters");
            }

            FullName = fullName;
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

        public void SetRole(string role)
        {
            if (!Identity.Role.IsValid(role))
            {
                throw new PKShopException(ErrorCodes.InvalidRole,
                    $"Invalid role: '{role}'.");
            }

            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new PKShopException(ErrorCodes.InvalidPassword,
                    "Password can not be empty.");
            }

            Password = passwordHasher.HashPassword(this, password);
        }

        public bool ValidatePassword(string password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(this, Password, password) != PasswordVerificationResult.Failed;
    }
}
