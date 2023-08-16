using Blazor.BrowserExtension.Pages;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using testprog.CqrsCore.Dispatcher;
using testprog.OptionModule.Domain.UseCases.Queries;
using testprog.PopupModule.Domain.UseCases.Commands;
using testprog.PopupModule.Domain.UseCases.Handlers.QueryHandlers;
using testprog.PopupModule.Domain.UseCases.Queries;
using testprog.PopupModule.Infrastructure.DTOModels;
using WebExtensions.Net.Management;

namespace testprog.PopupModule.Presentation.ViewModels
{
    public class PopupViewModel : BasePage
    {
        public int Progress { get; private set; } = 100;
        public bool Active
        {
            get;
            private set;
        } = true;

        public List<DateTime> SelectorDates { get; private set; } = new List<DateTime>();
        public List<SedTaskDTO> CurrentTasks { get; private set; } = new();
        private DateTime _currentDate;
        public DateTime CurrentDate 
        { 
            get => _currentDate;
            private set
            {
                if (_currentDate != value)
                {
                    _currentDate = value;
                }
            }
        }
        [Inject]
        public IQueryDispatcher QD { get; set; }
        [Inject]
        public ICommandDispatcher CD { get; set; }
        private string _Token { get; set; }
        public PopupViewModel() 
        {
            CurrentDate = DateTime.Now;
        }
        private async void UpdateTasks()
        {
            this.Active = false;
            Progress = 0;
            DateTime createFrom = new DateTime(DateTime.Now.Year, 01, 01);
            DateTime createTo = DateTime.Now.AddDays(1);
            DateTime from = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            DateTime to = new DateTime(CurrentDate.Year, CurrentDate.Month, DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month));
            _Token = await QD.Execute<GetStorageFieldValue, Task<string?>>(new GetStorageFieldValue("token"));
            List<SedTaskDTO> list = await QD.Execute<GetAllControlTasks, Task<List<SedTaskDTO>>>(new GetAllControlTasks(_Token, createFrom, createTo, from, to));
            CD.Execute(new RemoveAllSedTasks());
            CD.Execute(new AddSedTasks(list));
            CurrentTasks = QD.Execute<GetSedTasksByDate, List<SedTaskDTO>>(new GetSedTasksByDate(CurrentDate));
            SelectorDates = QD.Execute<GetAllDatesOfTasks, List<DateTime>>(new GetAllDatesOfTasks());
            Progress = 100;
            this.Active = true;
            await InvokeAsync(StateHasChanged);
        }
        protected async override Task OnInitializedAsync()
        {
            DateTime createFrom = new DateTime(DateTime.Now.Year, 01, 01);
            DateTime createTo = DateTime.Now.AddDays(1);
            DateTime from = new DateTime(CurrentDate.Year, CurrentDate.Month, 1);
            DateTime to = new DateTime(CurrentDate.Year, CurrentDate.Month, DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month));
            _Token = await QD.Execute<GetStorageFieldValue, Task<string?>>(new GetStorageFieldValue("token"));
            List<SedTaskDTO> list = await QD.Execute<GetAllControlTasks, Task<List<SedTaskDTO>>>(new GetAllControlTasks(_Token, createFrom, createTo, from, to));
            CD.Execute(new RemoveAllSedTasks());
            CD.Execute(new AddSedTasks(list));
            CurrentTasks = QD.Execute<GetSedTasksByDate, List<SedTaskDTO>>(new GetSedTasksByDate(CurrentDate));
            SelectorDates = QD.Execute<GetAllDatesOfTasks, List<DateTime>>(new GetAllDatesOfTasks());
            await InvokeAsync(StateHasChanged);
        }
        public async void SetCurrentDate(DateTime date)
        {
            Progress = 0;
            CurrentDate = date;
            CurrentTasks = QD.Execute<GetSedTasksByDate, List<SedTaskDTO>>(new GetSedTasksByDate(CurrentDate));
            await InvokeAsync(StateHasChanged);
        }
        public async void AddMonth(bool sign = true)
        {
            DateTime newDate = CurrentDate.AddMonths(sign?1:-1);
            CurrentDate = new DateTime(newDate.Year, newDate.Month, 01);
            UpdateTasks();
        }
    }
}