using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Framework.Commands
{
    public abstract class CommandHandler<TCommand> where TCommand : ICommand
    {
        private readonly CommandResult _result = new CommandResult();
        private readonly IResourceManager _resourceManager;
        public CommandHandler(IResourceManager resourceManager)
        {
            _resourceManager = resourceManager;
        }
  
        protected CommandResult Ok()
        {
            SetOkData();
            return _result;
        }

        protected CommandResult Ok(string message)
        {
            SetOkData();
            _result.Message = _resourceManager[message];
            return _result;
        }
        protected CommandResult Ok(string message, params string[] arguments)
        {
            SetOkData();
            _result.Message = _resourceManager[message, arguments];
            return _result;
        }
        private void SetOkData()
        {
            _result.ClearErrors();
            _result.IsSuccess = true;
        }
        protected CommandResult Failure()
        {
            SetFailureData();
            return _result;
        }
        protected CommandResult Failure(string message)
        {
            SetFailureData();
            _result.Message = _resourceManager[message];
            return _result;
        }
        protected CommandResult Failure(string message, params string[] arguments)
        {
            SetFailureData();
            _result.Message = _resourceManager[message, arguments];
            return _result;
        }
        private void SetFailureData()
        {
            _result.IsSuccess = false;
        }
        protected void AddError(string error)
        {
            _result.AddError(_resourceManager[error]);
        }
        protected void AddError(string error, params string[] arguments)
        {
            _result.AddError(_resourceManager[error, arguments]);
        }
        public abstract CommandResult Handle(TCommand command);

    }
}
