using System.Threading.Tasks;
using testprog.CqrsCore;
using testprog.OptionModule.Infrastructure.ApiDto;
namespace testprog.OptionModule.Domain.UseCases.Queries
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
