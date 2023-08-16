using AutoMapper;
using SelectorExtensionForChrome.CqrsCore;
using SelectorExtensionForChrome.OptionModule.Domain.UseCases.Commands;
using WebExtensions.Net;
using WebExtensions.Net.Storage;

namespace SelectorExtensionForChrome.OptionModule.Domain.UseCases.Handlers.CommandHadlers
{
    public class SetUserInformationHandler : ICommandHandler<SetUserInformation>
    {
        private readonly IWebExtensionsApi _webExtensions;
        public SetUserInformationHandler(IWebExtensionsApi webExtensions)
        {
            _webExtensions = webExtensions;
        }
        public async void Execute(SetUserInformation information)
        {
            var storage = await _webExtensions.Storage.GetLocal();
            await storage.Set(information.Information);
        }
    }
}
