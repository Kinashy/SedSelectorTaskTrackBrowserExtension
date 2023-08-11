using Blazor.BrowserExtension.Pages;
using System;
using System.Collections.Generic;
using testprog.PopupModule.Infrastructure.DTOModels;

namespace testprog.PopupModule.Presentation.ViewModels
{
    public class PopupViewModel : BasePage
    {
        public List<DateTime> SelectorDates { get; } = new List<DateTime>();
        public List<SedTaskDTO> CurrentTasks { get; private set; }
        public DateTime CurrentDate { get; }
    }
}