﻿using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using testprog.Models;
using WebExtensions.Net.Storage;
using Blazor.BrowserExtension.Pages;
using Blazor.BrowserExtension;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Net.Http.Json;

namespace testprog.ViewModels
{
    public class PopupViewModel : BasePage
    {
        [Inject]
        public HttpClient HttpClient { get; set; }
        private StorageArea _StorageArea { get; set; }
        private DateTime _currentDate = DateTime.Now;
        public DateTime CurrentDate { get => _currentDate; }
        public string Status { get; set; }
        private TaskControlRequestBodyResponsibleExecutor _ResponsibleExecutor { get; init; }
        private string _OtherUserId { get; init; }
        private TaskControlRequestBodyTaskFilter _ControlTaskDTO { get; set; }
        private TaskControlResponseSedTask[] _taskControlResponseSedTasks;
        public TaskControlResponseSedTask[] Tasks { get => _taskControlResponseSedTasks; }
        public PopupViewModel() : base()
        {
            _ResponsibleExecutor = new TaskControlRequestBodyResponsibleExecutor()
            {
                departmentName = null,
                fio = "Селектор Селектор Селектор",
                sectionName = "06 Отдел эксплуатации информационных систем, технических средств и каналов связи"
            };
            _OtherUserId = "64bf397c6e4354b45ea2bb8c";
        }
        protected override async Task OnInitializedAsync()
        {
            _StorageArea = await WebExtensions.Storage.GetLocal();
            _ControlTaskDTO = await BuildControlTaskDTO(CurrentDate);
            if (_ControlTaskDTO is not null)
            {
                var response = await HttpClient.PostAsJsonAsync("api/task/taskControl", _ControlTaskDTO);
                if (response.IsSuccessStatusCode)
                {
                    _taskControlResponseSedTasks = await response.Content.ReadFromJsonAsync<TaskControlResponseSedTask[]>();
                    
                }
                else
                {
                    //
                }
            }
            else
            {
                //
            }
            await base.OnInitializedAsync();
        }
        private TaskControlResponseSedTask[] GetSortedTask(TaskControlResponseSedTask[] tasks)
        {
            foreach (var task in tasks)
            {
                
            }
            return tasks;
        }
        public void AddMonth(bool sign = true)
        {
            int countMonths = 1;
            if (sign)
                countMonths = -1;
            _currentDate = new DateTime(_currentDate.AddMonths(countMonths).Year, _currentDate.AddMonths(countMonths).Month, 1);
        }
        private async Task<string> GetToken()
        {
             var res = await _StorageArea.Get(new WebExtensions.Net.Storage.StorageAreaGetKeys("token"));
             return res.GetProperty("token").ToString();
        }
        private async Task<TaskControlRequestBodyTaskFilter> BuildControlTaskDTO(DateTime date)
        {
            TaskControlRequestBodyTaskFilter body = new();
            string token = await GetToken();
            if ((token == null) || (token == string.Empty) || (token == ""))
            {
                //
                return null;
            }
            body.otherUserId = _OtherUserId;
            body.token = token;
            DateTime startMonth = new DateTime(date.Year, date.Month, 1);
            startMonth = startMonth.AddDays(-2);
            DateTime finishMonth = new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));
            finishMonth = finishMonth.AddDays(2);
            body.from = $"{startMonth.ToString("yyyy")}-{startMonth.ToString("MM")}-{startMonth.ToString("dd")}T00:00:00.000+03:00";
            body.to = $"{finishMonth.ToString("yyyy")}-{finishMonth.ToString("MM")}-{finishMonth.ToString("dd")}T00:00:00.000+03:00";
            body.createFrom = $"{date.ToString("yyyy")}-01-01T00:00:00.000Z";
            body.createTo = $"{DateTime.Now.ToString("yyyy")}-{DateTime.Now.ToString("MM")}-{DateTime.Now.AddDays(1).ToString("dd")}T00:00:00.000Z";
            return body;
        }
    }
}