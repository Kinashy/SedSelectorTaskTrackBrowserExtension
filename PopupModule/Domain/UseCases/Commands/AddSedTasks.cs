using System.Collections.Generic;
using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.PopupModule.Infrastructure.DTOModels;
using WebExtensions.Net.Menus;

namespace SelectorExtensionForChrome.PopupModule.Domain.UseCases.Commands
{
    public class AddSedTasks : ICommand
    {
        public List<SedTaskDTO> SedTasks { get; }
        public AddSedTasks(List<SedTaskDTO> sedTasks)
        {
            SedTasks = sedTasks;
        }
    }
}
