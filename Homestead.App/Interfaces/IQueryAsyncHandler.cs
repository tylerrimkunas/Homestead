using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Interfaces
{
    public interface IQueryAsyncHandler<TQuery, TResult> where TQuery : class
    {
        public Task<TResult> Query(TQuery query);
    }
}
