using AutoMapper;
using testprog.CqrsCore;
using testprog.OptionModule.Domain.UseCases.Commands;
using WebExtensions.Net;
using WebExtensions.Net.Storage;

namespace testprog.OptionModule.Domain.UseCases.Handlers.CommandHadlers
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
