using Accelerator.Core.ApplicationServices.Services;
using Accelerator.Core.Domain.Authors.Dtoes;
using Accelerator.Core.Domain.Authors.Entities;
using Accelerator.Core.Domain.Authors.Repositories;
using Accelerator.Core.Domain.Authors.ResourceParameters;
using Accelerator.Framework.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Infrastructures.Data.SqlServer.Authors.Repositories
{
    public class AuthorQueryRepository : IAuthorQueryRepository
    {
        private readonly AcceleratorDbContext _db;
        private readonly IPropertyMappingSerivce _propertyMappingService;
        public AuthorQueryRepository(AcceleratorDbContext db,
                                     IPropertyMappingSerivce propertyMappingService)
        {
            _db = db;
            _propertyMappingService = propertyMappingService;
        }
        public Author Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public PagedList<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters)
        {
            if (authorsResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(authorsResourceParameters));
            }

            //if (string.IsNullOrWhiteSpace(authorsResourceParameters.MainCategory)
            //    && string.IsNullOrWhiteSpace(authorsResourceParameters.SearchQuery))
            //{
            //    return await GetAuthorsAsync();
            //}

            // collection to start from
            var collection = _db.Authors as IQueryable<Author>;

            if (!string.IsNullOrWhiteSpace(authorsResourceParameters.MainCategory))
            {
                var mainCategory = authorsResourceParameters.MainCategory.Trim();
                collection = collection.Where(a => a.MainCategory == mainCategory);
            }

            if (!string.IsNullOrWhiteSpace(authorsResourceParameters.SearchQuery))
            {
                var searchQuery = authorsResourceParameters.SearchQuery.Trim();
                collection = collection.Where(a => a.MainCategory.Contains(searchQuery)
                   || a.FirstName.Contains(searchQuery)
                   || a.LastName.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(authorsResourceParameters.OrderBy))
            {
                // get property mapping dictionary
                var authorPropertyMappingDictionary = _propertyMappingService
                    .GetPropertyMapping<AuthorDto, Author>();

                collection = collection.ApplySort(authorsResourceParameters.OrderBy,
                    authorPropertyMappingDictionary);
            }

            return  PagedList<Author>.Create(collection,
                 authorsResourceParameters.PageNumber,
                 authorsResourceParameters.PageSize);
        }

        public async Task<PagedList<Author>> GetAuthorsAsync(AuthorsResourceParameters authorsResourceParameters)
        {
            if (authorsResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(authorsResourceParameters));
            }

            //if (string.IsNullOrWhiteSpace(authorsResourceParameters.MainCategory)
            //    && string.IsNullOrWhiteSpace(authorsResourceParameters.SearchQuery))
            //{
            //    return await GetAuthorsAsync();
            //}

            // collection to start from
            var collection = _db.Authors as IQueryable<Author>;

            if (!string.IsNullOrWhiteSpace(authorsResourceParameters.MainCategory))
            {
                var mainCategory = authorsResourceParameters.MainCategory.Trim();
                collection = collection.Where(a => a.MainCategory == mainCategory);
            }

            if (!string.IsNullOrWhiteSpace(authorsResourceParameters.SearchQuery))
            {
                var searchQuery = authorsResourceParameters.SearchQuery.Trim();
                collection = collection.Where(a => a.MainCategory.Contains(searchQuery)
                   || a.FirstName.Contains(searchQuery)
                   || a.LastName.Contains(searchQuery));
            }

            if (!string.IsNullOrWhiteSpace(authorsResourceParameters.OrderBy))
            {
                // get property mapping dictionary
                var authorPropertyMappingDictionary = _propertyMappingService
                    .GetPropertyMapping<AuthorDto, Author>();

                collection = collection.ApplySort(authorsResourceParameters.OrderBy,
                    authorPropertyMappingDictionary);
            }

            return await PagedList<Author>.CreateAsync(collection,
                 authorsResourceParameters.PageNumber,
                 authorsResourceParameters.PageSize);
        }
    }
}
