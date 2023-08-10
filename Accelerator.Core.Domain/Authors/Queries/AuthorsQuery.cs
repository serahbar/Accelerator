using Accelerator.Core.Domain.Authors.ResourceParameters;
using Accelerator.Framework.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Core.Domain.Authors.Queries
{
    public class AuthorsQuery : IQuery
    {
        public AuthorsResourceParameters AuthorsResourceParameters { get; set; }
    }
}
