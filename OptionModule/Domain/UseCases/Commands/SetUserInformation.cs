using System.Windows.Input;
using testprog.OptionModule.Infrastructure.ApiDto;

namespace testprog.OptionModule.Domain.UseCases.Commands
{
    public class SetUserInformation : CqrsCore.ICommand
    {
        public LoginEntityResponse Information { get; }
        public SetUserInformation(LoginEntityResponse information)
        {
            Information = information;
        }
    }
}