using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Framework.Queries
{
    public sealed class QueryDispatcher
    {
        private readonly IServiceProvider _provider;

        public QueryDispatcher(IServiceProvider provider)
        {
            _provider = provider;
        }

        public T Dispatch<T>(IQuery query)
        {
            Type type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };
            Type handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);
            T result = handler.Handle((dynamic)query);
            return result;
        }
    }
}
