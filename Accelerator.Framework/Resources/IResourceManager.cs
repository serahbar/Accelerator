using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accelerator.Framework.Resources
{
    public interface IResourceManager
    {
        string GetName(string name);
        string GetName(string name, params string[] arguments);
        string this[string name] { get; }
        string this[string name, params string[] arguments] { get; }
    }
}
