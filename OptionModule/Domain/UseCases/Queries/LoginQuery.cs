using System.Threading.Tasks;
using testprog.CqrsCore;
using testprog.OptionModule.Infrastructure.ApiDto;
namespace testprog.OptionModule.Domain.UseCases.Queries
{
    public class LoginQuery : IQuery<Task<UserInformation>>
    {
        public string UserName { get; }
        public string Password { get; }
        public LoginQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
