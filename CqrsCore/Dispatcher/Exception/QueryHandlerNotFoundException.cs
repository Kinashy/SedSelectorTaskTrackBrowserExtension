using System;

namespace SelectorExtensionForChrome.CqrsCore.Dispatcher.Exception
{
    public class QueryHandlerNotFoundException : ArgumentNullException
    {
        public Type Type { get; set; }

        public QueryHandlerNotFoundException(Type type)
        {
            this.Type = type;
        }

        public QueryHandlerNotFoundException(Type type, string name) : base(name)
        {
            this.Type = type;
        }

        public QueryHandlerNotFoundException(Type type, string name, string message) : base(name, message)
        {
            this.Type = type;
        }
    }
}
