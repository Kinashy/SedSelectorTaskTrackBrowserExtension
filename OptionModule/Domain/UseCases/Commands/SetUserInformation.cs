using System.Windows.Input;
using testprog.OptionModule.Infrastructure.ApiDto;

namespace testprog.OptionModule.Domain.UseCases.Commands
{
    public class SetUserInformation : CqrsCore.ICommand
    {
        public UserInformation Information { get; }
        public SetUserInformation(UserInformation information)
        {
            Information = information;
        }
    }
}