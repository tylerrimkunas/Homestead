using System;
using System.Collections.Generic;
using System.Text;

namespace Homestead.App.Interfaces
{
    public interface ICommandHandler<TCommand> where TCommand : class
    {
        public void Handle(TCommand command);
    }
    public interface ICommandHandler<TCommand, TResult> where TCommand : class
    {
        public TResult Handle(TCommand command);
    }
}
