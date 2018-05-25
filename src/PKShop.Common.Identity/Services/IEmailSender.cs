using System.Threading.Tasks;

namespace PKShop.Common.Identity.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}