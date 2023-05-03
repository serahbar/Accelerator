using Accelerator.Core.Domain.Courses.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Core.Domain.Authors.Dtoes
{
    public class AuthorForCreationDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTimeOffset DateOfBirth { get; set; }
        public string MainCategory { get; set; } = string.Empty;
        public ICollection<CourseForCreationDto> Courses { get; set; }
            = new List<CourseForCreationDto>();
    }
}
