using Accelerator.Core.Domain.Authors.Entities;
using Accelerator.Core.Domain.Authors.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Infrastructures.Data.SqlServer.Authors.Repositories
{
    public class AuthorQueryRepository : IAuthorQueryRepository
    {
        public Author Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
