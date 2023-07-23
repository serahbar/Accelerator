using Accelerator.Core.Domain.Authors.Dtoes;
using Accelerator.Core.Domain.Authors.Entities;
using Accelerator.Endpoints.WebAPI.ResourceParameters;
using Accelerator.Endpoints.WebAPI.Services;
using Accelerator.Framework.Commands;
using Accelerator.Framework.Queries;
using Accelerator.Framework.Resources;
using Accelerator.Framework.Web;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Accelerator.Endpoints.WebAPI.Controllers
{
    [ApiController]
    [Route("api/authors")]
    public class AuthorsController : BaseApiController
    {
        private readonly IPropertyMappingSerivce _propertyMappingService;
        private readonly IPropertyCheckerService _propertyCheckerService;
        private readonly IMapper _mapper;
        private readonly ProblemDetailsFactory _problemDetailsFactory;
        public AuthorsController(CommandDispatcher commandDispatcher,
                        QueryDispatcher queryDispatcher,
                        IMapper mapper,
                        IPropertyMappingSerivce propertyMappingService,
                        IPropertyCheckerService propertyCheckerService,
                        ProblemDetailsFactory problemDetailsFactory,
                        IResourceManager resourceManager) : base(commandDispatcher, queryDispatcher, resourceManager)
        {
            _mapper = mapper ??
     throw new ArgumentNullException(nameof(mapper));
            _propertyMappingService = propertyMappingService ??
                throw new ArgumentNullException(nameof(propertyMappingService));
            _propertyCheckerService = propertyCheckerService ??
                throw new ArgumentNullException(nameof(propertyCheckerService));
            _problemDetailsFactory = problemDetailsFactory ??
    throw new ArgumentNullException(nameof(problemDetailsFactory));
        }
        [HttpGet(Name = "GetAuthors")]
        public async Task<IActionResult> GetAuthors(
            [FromQuery] AuthorsResourceParameters authorsResourceParameters)
        {
            if (!_propertyMappingService
                    .ValidMappingExistsFor<AuthorDto, Author>(
        authorsResourceParameters.OrderBy))
            {
                return BadRequest();
            }
            if (!_propertyCheckerService.TypeHasProperties<AuthorDto>
                        (authorsResourceParameters.Fields))
            {
                return BadRequest(
                    _problemDetailsFactory.CreateProblemDetails(HttpContext,
                        statusCode: 400,
                        detail: $"Not all requested data shaping fields exist on " +
                        $"the resource: {authorsResourceParameters.Fields}"));
            }

            var authorsFromRepo = _queryDispatcher.Dispatch<>
       .GetAuthorsAsync(authorsResourceParameters);
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
