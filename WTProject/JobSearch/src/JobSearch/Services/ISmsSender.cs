using System.Threading.Tasks;

namespace JobSearch.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
