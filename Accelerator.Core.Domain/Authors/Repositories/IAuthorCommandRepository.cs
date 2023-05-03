using Accelerator.Core.Domain.Authors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Core.Domain.Authors.Repositories
{
    public interface IAuthorCommandRepository
    {
        void Add(Author author);
    }
}
