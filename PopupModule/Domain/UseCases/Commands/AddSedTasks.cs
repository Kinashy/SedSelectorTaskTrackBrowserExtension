using System.Collections.Generic;
using testprog.CqrsCore;
using testprog.PopupModule.Infrastructure.DTOModels;
using WebExtensions.Net.Menus;

namespace testprog.PopupModule.Domain.UseCases.Commands
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
