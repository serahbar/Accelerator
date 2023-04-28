using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Framework.Domain
{
    public class BaseEntity
    {
        //Next step will be: generating Guid depond on Time for sorting
        public Guid Id { get; set; }
    }
}
