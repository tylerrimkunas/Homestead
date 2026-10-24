using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Interfaces
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : class
    {
        public TResult Query(TQuery query);
    }
}
