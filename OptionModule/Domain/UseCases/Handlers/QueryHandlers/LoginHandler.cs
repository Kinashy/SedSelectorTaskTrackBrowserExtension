using AutoMapper;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using testprog.CqrsCore;
using testprog.OptionModule.Domain.UseCases.Queries;
using testprog.OptionModule.Infrastructure.ApiDto;

namespace testprog.OptionModule.Domain.UseCases.Handlers.QueryHandlers
{
    public class LoginHandler : IQueryHandler<Login, Task<LoginEntityResponse>>
    {
        private readonly HttpClient _httpClient;
        public LoginHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LoginEntityResponse> Execute(Login loginToSed)
        {
            LoginEntityResponse userInformation = null;
            try
            {
                LoginRequest requestBody = new LoginRequest();
                requestBody.password = loginToSed.Password;
                requestBody.login = loginToSed.UserName;
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", requestBody);
                if (response.IsSuccessStatusCode)
                {
                    userInformation = await response.Content.ReadFromJsonAsync<LoginEntityResponse>();
                }
                else
                {
                    userInformation = null;
                }
                response.Dispose();
                return userInformation;
            }
            catch
            {
                userInformation = null;
            }
            return userInformation;
        }
    }
}
