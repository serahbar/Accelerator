using Accelerator.Framework.Commands;
using Accelerator.Framework.Queries;
using Accelerator.Framework.Resources;
using Accelerator.Framework.Web;
using Microsoft.AspNetCore.Mvc;

namespace Accelerator.Endpoints.WebAPI.Controllers
{
    public class AuthorsController : BaseApiController
    {
      

        public AuthorsController(CommandDispatcher commandDispatcher,
                QueryDispatcher queryDispatcher,
                IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }
        public async Task<IActionResult> GetAuthors()
        {
            //TODO:Test
            return null;
        }
        
    }
}
