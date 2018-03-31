using System;
using System.Text.RegularExpressions;

namespace CompanyCars.Core.Domain
{
    public class User : BaseEntity
    {
        private static readonly Regex EmailRegex = new Regex(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

        public Guid SerialNumber { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public string Role { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
    }
}
