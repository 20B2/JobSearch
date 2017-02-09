using System.Threading.Tasks;

namespace JobSearch.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
