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
            //var res = await _StorageArea.Get(new WebExtensions.Net.Storage.StorageAreaGetKeys("token"));
            //return res.GetProperty("token").ToString();
            var storage = await _webExtensions.Storage.GetLocal();
            var res = await storage.Get(new WebExtensions.Net.Storage.StorageAreaGetKeys(field.Field));
            return res.GetProperty(field.Field).ToString();
        }
    }
}
