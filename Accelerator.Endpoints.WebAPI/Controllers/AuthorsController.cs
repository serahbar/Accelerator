using Accelerator.Core.Domain.Authors.Dtoes;
using Accelerator.Framework.Commands;
using Accelerator.Framework.Queries;
using Accelerator.Framework.Resources;
using Accelerator.Framework.Web;
using Microsoft.AspNetCore.Mvc;

namespace Accelerator.Endpoints.WebAPI.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : BaseApiController
    {


        public AuthorsController(CommandDispatcher commandDispatcher,
                QueryDispatcher queryDispatcher,
                IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
        }
        [HttpGet(Name = "GetAuthors")]
        public async Task<IActionResult> GetAuthors(
            [FromQuery] AuthorsResourceParameters authorsResourceParameters)
        {
            //TODO:Test
            return Ok();
        }
        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetFullAuthorWithLinks(Guid authorId,
    string? fields)
        {
            return Ok();
        }
        [HttpGet("{authorId}", Name = "GetAuthor")]
        public async Task<IActionResult> GetFullAuthorWithoutLinks(Guid authorId,
    string? fields)
        {
            return Ok();
        }
        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetAuthorWithLinks(Guid authorId,
    string? fields)
        {
            return Ok();
        }
        [HttpGet("{authorId}", Name = "GetAuthor")]
        public async Task<IActionResult> GetAuthorWithoutLinks(Guid authorId,
    string? fields)
        {
            return Ok();
        }
        [HttpPost(Name = "CreateAuthorWithDateOfDeath")]
        public async Task<IActionResult> CreateAuthorWithDateOfDeath(AuthorForCreationWithDateOfDeathDto author)
        {
            return Ok();
        }
        [HttpPost(Name = "CreateAuthor")]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(
     AuthorForCreationDto author)
        {
            return Ok();
        }
        [HttpOptions()]
        public IActionResult GetAuthorsOptions()
        {
            Response.Headers.Add("Allow", "GET,HEAD,POST,OPTIONS");
            return Ok();
        }

    }
}
