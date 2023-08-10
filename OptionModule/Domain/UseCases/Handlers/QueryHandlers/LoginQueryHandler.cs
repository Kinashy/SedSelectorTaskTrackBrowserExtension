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
    public class LoginQueryHandler : IQueryHandler<LoginQuery, Task<UserInformation>>
    {
        private readonly HttpClient _httpClient;
        public LoginQueryHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserInformation> Execute(LoginQuery loginToSed)
        {
            UserInformation userInformation = null;
            try
            {
                RequestAuthorization requestBody = new RequestAuthorization();
                requestBody.password = loginToSed.Password;
                requestBody.login = loginToSed.UserName;
                var response = await _httpClient.PostAsJsonAsync("api/auth/login", requestBody);
                if (response.IsSuccessStatusCode)
                {
                    userInformation = await response.Content.ReadFromJsonAsync<UserInformation>();
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
