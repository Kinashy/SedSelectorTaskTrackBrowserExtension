using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SelectorExtensionForChrome.PopupModule.Infrastructure.DTOModels;

namespace SelectorExtensionForChrome.PopupModule.Domain
{
    public interface ISedTaskRepository
    {
        public void AddList(List<SedTaskDTO> tasks);
        public List<SedTaskDTO> GetAllByDate(DateTime date);
        public void RemoveAll();
        public List<DateTime> GetDates();
    }
}
