using Accelerator.Core.Domain.Autors.Entities;

namespace Accelerator.Core.Domain.Autors.Repositories
{
    public interface IAuthorQueryRepository
    {
        Author Get(Guid id);
        List<Author> GetAll();
    }
}
