﻿namespace SelectorExtensionForChrome.CqrsCore
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
