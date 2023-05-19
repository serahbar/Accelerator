using Accelerator.Framework.Commands;
using Accelerator.Framework.Queries;
using Accelerator.Framework.Resources;
using Microsoft.AspNetCore.Mvc;

namespace Accelerator.Framework.Web
{
    [ApiController]
    public class BaseApiController: ControllerBase
    {
        protected readonly CommandDispatcher _commandDispatcher;
        protected readonly QueryDispatcher _queryDispatcher;
        protected readonly IResourceManager _resourceManager;

        public BaseApiController(CommandDispatcher commandDispatcher, 
                                    QueryDispatcher queryDispatcher,
                                        IResourceManager resourceManager)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _resourceManager = resourceManager;
        }

  
    }
}
