using Accelerator.Core.Domain.Authors.Dtoes;
using Accelerator.Core.Domain.Authors.Entities;
using Accelerator.Core.Domain.Courses.Entities;
using Accelerator.Framework.Commands;

namespace Accelerator.Core.Domain.Authors.Commands
{
    public class AddAuthorCommand :AuthorForCreationDto, ICommand
    {

    }
}
