using System.Threading.Tasks;
using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.OptionModule.Infrastructure.ApiDto;
namespace SelectorExtensionForChrome.OptionModule.Domain.UseCases.Queries
{
    public class Login : IQuery<Task<LoginEntityResponse>>
    {
        public string UserName { get; }
        public string Password { get; }
        public Login(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
