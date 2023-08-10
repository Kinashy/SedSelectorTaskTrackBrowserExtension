using Blazor.BrowserExtension.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using testprog.Models;
using WebExtensions.Net.Storage;

namespace testprog.ViewModels
{
    public class OptionViewModel : BasePage
    {
        [Inject]
        public HttpClient HttpClient { get; set; }
        private LoginRequestBodyEntry _loginRequestDTO = new();
        public LoginRequestBodyEntry LoginRequestDTO { get => _loginRequestDTO; }
        private LoginResponseRegisteredUserInformation _userInfo;
        public LoginResponseRegisteredUserInformation UserInfo { get => _userInfo; }
        private StorageArea _BrowserLocalStorage { get; set; }
        private string _status;
        public string Status
        {
            get => _status;
        }
        protected override async Task OnInitializedAsync()
        {
            _BrowserLocalStorage = await WebExtensions.Storage.GetLocal();
            await base.OnInitializedAsync();
        }
        public async void OnKeyPress(KeyboardEventArgs e)
        {
            if (e.Code == "Enter")
            {
                DoLoginRequest();
            }
        }
        public async void DoLoginRequest()
        {
            
            var response = await HttpClient.PostAsJsonAsync("api/auth/login", LoginRequestDTO);
            if (response.IsSuccessStatusCode)
            {
                _userInfo = await response.Content.ReadFromJsonAsync<LoginResponseRegisteredUserInformation>();
                await _BrowserLocalStorage.Set(UserInfo);
                var prop = await _BrowserLocalStorage.Get(new StorageAreaGetKeys("fio"));
                _status = "Добро пожаловать, " + prop.GetProperty("fio").ToString() + "!";
            }
            else 
            {
                _status = "Неверные логин и пароль";
            }
            response.Dispose();
            await InvokeAsync(StateHasChanged);
        }
    }
}