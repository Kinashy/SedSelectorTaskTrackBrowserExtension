using System;
using System.ComponentModel;
using System.Threading.Tasks;
using SelectorExtensionForChrome.CqrsCore.Dispatcher.Exception;

namespace SelectorExtensionForChrome.CqrsCore.Dispatcher
{
    public interface IQueryDispatcher
    {
        public bool Executing { get; }
        TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;

    }
    internal sealed class QueryDispatcher : IQueryDispatcher
    {
        public bool Executing { get; private set; } = false;
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResult Execute<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            this.Executing = true;
            if (query == null) throw new ArgumentNullException("query");

            var handler = (IQueryHandler<TQuery, TResult>)_serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResult>));

            if (handler == null) throw new QueryHandlerNotFoundException(typeof(TQuery));

            return handler.Execute(query);
            this.Executing = false;
        }
    }
}
