using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testprog.PopupModule.Domain;
using testprog.PopupModule.Infrastructure.DTOModels;

namespace testprog.PopupModule.Infrastructure
{
    public class SedTaskRepository : ISedTaskRepository
    {
        private List<SedTaskDTO> _tasks = new();
        public void AddList(List<SedTaskDTO> tasks)
        {
            _tasks.AddRange(tasks);
        }

        public List<SedTaskDTO> GetAllByDate(DateTime date)
        {
            return _tasks.Where(t => t.ExecutionDate.Contains($"{date.ToString("yyyy")}-{date.ToString("MM")}-{date.ToString("dd")}")).ToList();
        }

        public void RemoveAll()
        {
            _tasks.Clear();
        }
    }
}
