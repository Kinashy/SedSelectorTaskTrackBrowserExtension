using System.Threading.Tasks;
using System;
using SelectorExtensionForChrome.CqrsCore.Dispatcher.Exception;
using System.ComponentModel.Design;

namespace SelectorExtensionForChrome.CqrsCore.Dispatcher
{
    public interface ICommandDispatcher
    {
        public bool Executing { get;}
        void Execute<TCommand> (TCommand command) where TCommand : ICommand;
    }
    internal sealed class CommandDispatcher : ICommandDispatcher
    {
        public bool Executing { get; private set; } = false;
        private readonly IServiceProvider _serviceProvider;
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            this.Executing = true;
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handler = (ICommandHandler<TCommand>)_serviceProvider.GetService(typeof(ICommandHandler<TCommand>));

            if (handler == null) throw new CommandHandlerNotFoundException(typeof(TCommand));

            handler.Execute(command);
            this.Executing = false;
        }
    }
}