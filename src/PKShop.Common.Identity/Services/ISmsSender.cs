using System.Threading.Tasks;

namespace PKShop.Common.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}