using Accelerator.Core.Domain.Authors.Entities;

namespace Accelerator.Core.Domain.Authors.Repositories
{
    public interface IAuthorQueryRepository
    {
        Author Get(Guid id);
        List<Author> GetAll();
    }
}
