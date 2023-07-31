using Accelerator.Core.Domain.Authors.Dtoes;
using Accelerator.Core.Domain.Authors.Entities;
using Accelerator.Core.Domain.Authors.Queries;
using Accelerator.Core.Domain.Authors.Repositories;
using Accelerator.Framework.Extentions;
using Accelerator.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Core.ApplicationServices.Authors.Queries
{
    public class AuthorsQueryHandler : IQueryHandler<AuthorsQuery, PagedList<Author>>
    {
        private readonly IAuthorQueryRepository _authorQueryRepository;
        public AuthorsQueryHandler(IAuthorQueryRepository authorQueryRepository)
        {
            _authorQueryRepository = authorQueryRepository;
        }

        public PagedList<Author> Handle(AuthorsQuery query)
        {
            return _authorQueryRepository.GetAuthors(query.AuthorsResourceParameters);
        }

        public async Task<PagedList<Author>> HandleAsync(AuthorsQuery query)
        {
            return await _authorQueryRepository.GetAuthorsAsync(query.AuthorsResourceParameters);
        }





    }
}
