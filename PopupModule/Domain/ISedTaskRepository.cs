using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using testprog.PopupModule.Infrastructure.DTOModels;

namespace testprog.PopupModule.Domain
{
    public interface ISedTaskRepository
    {
        public void AddList(List<SedTaskDTO> tasks);
        public List<SedTaskDTO> GetAllByDate(DateTime date);
        public void RemoveAll();
        public List<DateTime> GetDates();
    }
}
