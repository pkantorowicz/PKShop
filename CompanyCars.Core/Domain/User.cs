using CompanyCars.Core.Exceptions;
using CompanyCars.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Text.RegularExpressions;

namespace CompanyCars.Core.Domain
{
    public class User : BaseEntity, IAggregateRoot
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public Guid UserIdentifier { get; protected set; }
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

        public User(Guid userIdentifier, string username, string email, string fullName, string role)
        {
            UserIdentifier = userIdentifier;
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
                throw new CompanyCarsException("Username is invalid.");
            }
            if (username.Length > 50)
            {
                throw new CompanyCarsException("Usename cannot be longer than 50 characters");
            }

            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetFullName(string fullName)
        {
            if (fullName.Length > 100)
            {
                throw new CompanyCarsException("Fullname cannot be longer than 100 characters");
            }

            FullName = fullName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (!email.Contains("@"))
            {
                throw new CompanyCarsException($"Invalid email: '{email}'");
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new CompanyCarsException("Email can not be empty.");
            }
            if (!EmailRegex.IsMatch(email))
            {
                throw new CompanyCarsException($"Invalid email: '{email}'.");
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
            if (!Domain.Role.IsValid(role))
            {
                throw new CompanyCarsException($"Invalid role: '{role}'.");
            }

            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, IPasswordHasher<User> passwordHasher)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new CompanyCarsException("Password can not be empty.");
            }

            Password = passwordHasher.HashPassword(this, password);
        }

        public bool ValidatePassword(string password, IPasswordHasher<User> passwordHasher)
            => passwordHasher.VerifyHashedPassword(this, Password, password) != PasswordVerificationResult.Failed;
    }
}
