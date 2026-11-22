using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Interfaces
{
    public interface ICommandAsyncHandler<TCommand> where TCommand : class
    {
        public Task Handle(TCommand command);
    }
    public interface ICommandAsyncHandler<TCommand, TResult> where TCommand : class
    {
        public Task<TResult> Handle(TCommand command);
    }
}
