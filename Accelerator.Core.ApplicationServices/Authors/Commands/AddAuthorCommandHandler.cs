using Accelerator.Core.Domain.Authors.Commands;
using Accelerator.Core.Domain.Authors.Repositories;
using Accelerator.Framework.Commands;
using Accelerator.Framework.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Core.ApplicationServices.Authors.Commands
{
    public class AddAuthorCommandHandler : CommandHandler<AddAuthorCommand>
    {
        private readonly IAuthorCommandRepository _commandRepository;   
        public AddAuthorCommandHandler(IResourceManager resourceManager,IAuthorCommandRepository commandRepository): base(resourceManager)
        {
            _commandRepository = commandRepository;
        }
        public override CommandResult Handle(AddAuthorCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
