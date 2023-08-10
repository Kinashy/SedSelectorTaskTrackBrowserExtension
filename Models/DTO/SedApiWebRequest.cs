using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using testprog.Shared;
using WebExtensions.Net.DeclarativeNetRequest;

namespace testprog.Models.DTO
{
    public class SedApiWebRequest
    {
        public HttpClient HttpClient { get; init; }
        public SedApiWebRequest(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }
    }
}