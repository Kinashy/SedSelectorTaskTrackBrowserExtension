using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace testprog.Models
{
    public class SedApiAuthWebTransation
    {
        private LoginResponseRegisteredUserInformation? userInformation;
        public LoginResponseRegisteredUserInformation? UserInformation { get => userInformation; }
        public LoginRequestBodyEntry AuthInformation { get; init; }
        public HttpClient HttpClient { get; init; }
        public SedApiAuthWebTransation(HttpClient httpClient, LoginRequestBodyEntry loginRequestBodyEntry)
        {
            HttpClient = httpClient;
            AuthInformation = loginRequestBodyEntry;
        }
        public async Task Send(CancellationToken ct)
        {
            
        }
    }
}
