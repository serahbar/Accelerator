using Accelerator.Framework.Queries;

namespace Accelerator.Core.Domain.Authors.Queries
{
    public class AuthorQuery : IQuery
    {
        public Guid Id { get; set; }
    }
}
