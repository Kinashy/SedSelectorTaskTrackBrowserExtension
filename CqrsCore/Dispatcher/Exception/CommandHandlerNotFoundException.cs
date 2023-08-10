using System;

namespace testprog.CqrsCore.Dispatcher.Exception
{
    public class CommandHandlerNotFoundException : ArgumentNullException
    {
        public Type Type { get; set; }

        public CommandHandlerNotFoundException(Type type)
        {
            this.Type = type;
        }

        public CommandHandlerNotFoundException(Type type, string name) : base(name)
        {
            this.Type = type;
        }

        public CommandHandlerNotFoundException(Type type, string name, string message) : base(name, message)
        {
            this.Type = type;
        }
    }
}
