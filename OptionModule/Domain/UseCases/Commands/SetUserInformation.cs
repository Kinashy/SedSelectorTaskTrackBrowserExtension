using System.Windows.Input;
using SelectorExtensionForChrome.OptionModule.Infrastructure.ApiDto;

namespace SelectorExtensionForChrome.OptionModule.Domain.UseCases.Commands
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