using Accelerator.Core.Domain.Courses.Entities;
using Accelerator.Framework.Domain;

namespace Accelerator.Core.Domain.Authors.Entities
{
    public class Author:BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AuthorType AuthorType { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public DateTimeOffset? DateOfDeath { get; set; }

        public string MainCategory { get; set; }

        public ICollection<Course> Courses { get; set; }
            = new List<Course>();

        public Author(string firstName, string lastName, string mainCategory)
        {
            FirstName = firstName;
            LastName = lastName;
            MainCategory = mainCategory;
        }
    }
}
