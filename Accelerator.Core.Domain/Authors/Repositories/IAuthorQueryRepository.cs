using Accelerator.Core.Domain.Authors.Dtoes;
using Accelerator.Core.Domain.Authors.Entities;
using Accelerator.Core.Domain.Authors.ResourceParameters;
using Accelerator.Framework.Extentions;

namespace Accelerator.Core.Domain.Authors.Repositories
{
    public interface IAuthorQueryRepository
    {
        Author Get(Guid id);
        List<Author> GetAll();
        Task<PagedList<Author>> GetAuthorsAsync(AuthorsResourceParameters authorsResourceParameters);
        PagedList<Author> GetAuthors(AuthorsResourceParameters authorsResourceParameters);
    }
}
