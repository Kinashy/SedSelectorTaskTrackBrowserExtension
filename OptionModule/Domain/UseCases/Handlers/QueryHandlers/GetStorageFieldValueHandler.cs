using System.IO;
using System.Threading.Tasks;
using testprog.CqrsCore;
using testprog.OptionModule.Domain.UseCases.Queries;
using WebExtensions.Net;
using WebExtensions.Net.Storage;

namespace testprog.OptionModule.Domain.UseCases.Handlers.QueryHandlers
{
    public class GetStorageFieldValueHandler : IQueryHandler<GetStorageFieldValue, Task<string?>>
    {
        private IWebExtensionsApi _webExtensions;
        public GetStorageFieldValueHandler(IWebExtensionsApi webExtensions)
        {
            _webExtensions = webExtensions;
        }
        public async Task<string?> Execute(GetStorageFieldValue field)
        {
            var storage = await _webExtensions.Storage.GetLocal();
            return (await storage.Get(new StorageAreaGetKeys("fio"))).GetProperty(field.Field).ToString();
        }
    }
}
