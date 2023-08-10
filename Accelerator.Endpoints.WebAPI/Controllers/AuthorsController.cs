using Accelerator.Core.ApplicationServices.Services;
using Accelerator.Core.Domain.Authors.Dtoes;
using Accelerator.Core.Domain.Authors.Entities;
using Accelerator.Core.Domain.Authors.Queries;
using Accelerator.Core.Domain.Authors.ResourceParameters;

using Accelerator.Framework.Commands;
using Accelerator.Framework.Extentions;
using Accelerator.Framework.Queries;
using Accelerator.Framework.Resources;
using Accelerator.Framework.Web;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text.Json;

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
                    .ValidMappingExistsFor<AuthorDto, Author>(authorsResourceParameters.OrderBy))
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
            //TODO:MediatR
            var authorsFromRepo = _queryDispatcher
                                    .Dispatch<PagedList<Author>>(new AuthorsQuery() { AuthorsResourceParameters= authorsResourceParameters});
            var paginationMetadata = new
            {
                totalCount = authorsFromRepo.TotalCount,
                pageSize = authorsFromRepo.PageSize,
                currentPage = authorsFromRepo.CurrentPage,
                totalPages = authorsFromRepo.TotalPages
            };

            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(paginationMetadata));

            // create links
            var links = CreateLinksForAuthors(authorsResourceParameters,
                authorsFromRepo.HasNext,
                authorsFromRepo.HasPrevious);
            var shapedAuthors = _mapper.Map<IEnumerable<AuthorDto>>(authorsFromRepo)
                               .ShapeData(authorsResourceParameters.Fields);
            var shapedAuthorsWithLinks = shapedAuthors.Select(author =>
            {
                var authorAsDictionary = author as IDictionary<string, object?>;
                var authorLinks = CreateLinksForAuthor(
                    (Guid)authorAsDictionary["Id"],
                    null);
                authorAsDictionary.Add("links", authorLinks);
                return authorAsDictionary;
            });

            var linkedCollectionResource = new
            {
                value = shapedAuthorsWithLinks,
                links = links
            };
            
            return Ok(linkedCollectionResource);
        }

        private IEnumerable<LinkDto> CreateLinksForAuthors(
            AuthorsResourceParameters authorsResourceParameters,
            bool hasNext, 
            bool hasPrevious)

        {
            var links = new List<LinkDto>();

            // self 
            links.Add(
                new(CreateAuthorsResourceUri(authorsResourceParameters,
                    ResourceUriType.Current),
                    "self",
                    "GET"));

            if (hasNext)
            {
                links.Add(
                    new(CreateAuthorsResourceUri(authorsResourceParameters,
                        ResourceUriType.NextPage),
                    "nextPage",
                    "GET"));
            }

            if (hasPrevious)
            {
                links.Add(
                    new(CreateAuthorsResourceUri(authorsResourceParameters,
                        ResourceUriType.PreviousPage),
                    "previousPage",
                    "GET"));
            }

            return links;
        }
        private string? CreateAuthorsResourceUri(AuthorsResourceParameters authorsResourceParameters,ResourceUriType type)

        {
            switch (type)
            {
                case ResourceUriType.PreviousPage:
                    return Url.Link("GetAuthors",
                        new
                        {
                            fields = authorsResourceParameters.Fields,
                            orderBy = authorsResourceParameters.OrderBy,
                            pageNumber = authorsResourceParameters.PageNumber - 1,
                            pageSize = authorsResourceParameters.PageSize,
                            mainCategory = authorsResourceParameters.MainCategory,
                            searchQuery = authorsResourceParameters.SearchQuery
                        });
                case ResourceUriType.NextPage:
                    return Url.Link("GetAuthors",
                        new
                        {
                            fields = authorsResourceParameters.Fields,
                            orderBy = authorsResourceParameters.OrderBy,
                            pageNumber = authorsResourceParameters.PageNumber + 1,
                            pageSize = authorsResourceParameters.PageSize,
                            mainCategory = authorsResourceParameters.MainCategory,
                            searchQuery = authorsResourceParameters.SearchQuery
                        });
                case ResourceUriType.Current:
                default:
                    return Url.Link("GetAuthors",
                        new
                        {
                            fields = authorsResourceParameters.Fields,
                            orderBy = authorsResourceParameters.OrderBy,
                            pageNumber = authorsResourceParameters.PageNumber,
                            pageSize = authorsResourceParameters.PageSize,
                            mainCategory = authorsResourceParameters.MainCategory,
                            searchQuery = authorsResourceParameters.SearchQuery
                        });
            }
        }
        private IEnumerable<LinkDto> CreateLinksForAuthor(Guid authorId,string? fields)
        {
            var links = new List<LinkDto>();

            if (string.IsNullOrWhiteSpace(fields))
            {
                links.Add(
                  new(Url.Link("GetAuthor", new { authorId }),
                  "self",
                  "GET"));
            }
            else
            {
                links.Add(
                  new(Url.Link("GetAuthor", new { authorId, fields }),
                  "self",
                  "GET"));
            }

            links.Add(
                  new(Url.Link("CreateCourseForAuthor", new { authorId }),
                  "create_course_for_author",
                  "POST"));
            links.Add(
                 new(Url.Link("GetCoursesForAuthor", new { authorId }),
                 "courses",
                 "GET"));

            return links;
        }

        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetFullAuthorWithLinks(Guid authorId,string? fields)
        {
            return Ok();
        }
        [HttpGet("{authorId}", Name = "GetAuthor")]
        public async Task<IActionResult> GetFullAuthorWithoutLinks(Guid authorId,string? fields)
        {
            return Ok();
        }
        [HttpGet("{authorId}")]
        public async Task<IActionResult> GetAuthorWithLinks(Guid authorId,string? fields)
        {
            return Ok();
        }
        [HttpGet("{authorId}", Name = "GetAuthor")]
        public async Task<IActionResult> GetAuthorWithoutLinks(Guid authorId,string? fields)
        {
            return Ok();
        }
        [HttpPost(Name = "CreateAuthorWithDateOfDeath")]
        public async Task<IActionResult> CreateAuthorWithDateOfDeath(AuthorForCreationWithDateOfDeathDto author)
        {
            return Ok();
        }
        [HttpPost(Name = "CreateAuthor")]
        public async Task<ActionResult<AuthorDto>> CreateAuthor(AuthorForCreationDto author)
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
