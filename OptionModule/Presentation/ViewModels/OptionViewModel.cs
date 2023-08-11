using AutoMapper;
using Blazor.BrowserExtension.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;
using testprog.CqrsCore.Dispatcher;
using testprog.OptionModule.Domain.UseCases.Commands;
using testprog.OptionModule.Domain.UseCases.Queries;
using testprog.OptionModule.Infrastructure.ApiDto;

namespace testprog.OptionModule.Presentation.ViewModels
{
    public class OptionViewModel : BasePage
    {
        [Inject]
        public HttpClient HttpClient { get; set; }
        [Inject]
        public IMapper MyMapper { get; set; }
        [Inject]
        IQueryDispatcher QueryDispatcher { get; set; }
        [Inject]
        ICommandDispatcher CommandDispatcher { get; set; }
        [Required(ErrorMessage = "Пароль не введен!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Имя пользователя не введено!")]
        public string UserName { get; set; }
        public string Status { get; private set; }
        public int Progress { get; private set; }
        public bool Active
        {
            get;
            private set;
        } = true;
        public async void OnKeyPress(KeyboardEventArgs e)
        {
            if (e.Code == "Enter")
            {
                Login();
            }
        }
        public async void Login()
        {
            this.Active = false;
            Progress = 0;
            var userInfo = await QueryDispatcher.Execute<Login, Task<LoginEntityResponse>>(new Login(UserName, Password));
            if (userInfo != null)
            {
                CommandDispatcher.Execute<SetUserInformation>(new SetUserInformation(userInfo));
                await QueryDispatcher.Execute<GetStorageFieldValue, Task<string?>>(new GetStorageFieldValue("fio"));
                Status = $"Здравствуйте, {userInfo.fio}!";
            }
            else
            {
                Status = "Запрос на авторизацию имеет неверные данные.";
            }
            Progress = 100;
            this.Active = true;
            await InvokeAsync(StateHasChanged);
        }
    }
}