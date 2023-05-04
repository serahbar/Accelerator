using Accelerator.Core.Domain.Authors.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Core.Domain.Courses.Entities
{
    public class Course
    {

        public Guid Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public Author Author { get; set; } = null!;

        public Guid AuthorId { get; set; }

        public Course(string title)
        {
            Title = title;
        }
    }
}
