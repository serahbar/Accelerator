using Accelerator.Core.Domain.Courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Core.Domain.Courses.Repositories
{
    public interface ICourseCommandRepository
    {
        void Add(Course course);
    }
}
