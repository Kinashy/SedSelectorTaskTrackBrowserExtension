using Blazor.BrowserExtension.Pages;
using System;
using System.Collections.Generic;
using testprog.PopupModule.Infrastructure.DTOModels;

namespace testprog.PopupModule.Presentation.ViewModels
{
    public class PopupViewModel : BasePage
    {
        public List<SedTaskDTO> _AllTasks { get; private set; }
        public DateTime CurrentDate { get; set; }
        public PopupViewModel() { }
    }
}
