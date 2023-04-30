using Accelerator.Core.Domain.Autors.Entities;
using Accelerator.Core.Domain.Courses.Entities;
using Accelerator.Framework.Commands;

namespace Accelerator.Core.Domain.Autors.Commands
{
    public class AddAuthorCommand : ICommand
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AuthorType AuthorType { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }

        public DateTimeOffset? DateOfDeath { get; set; }

        public string MainCategory { get; set; }

        public ICollection<Course>? Courses { get; set; }
            = new List<Course>();
    }
}
