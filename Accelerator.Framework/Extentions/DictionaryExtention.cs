using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Accelerator.Framework.Extentions
{
    public static class DictionaryExtention
    {
        public static Dictionary<string,string> StringToDectionary(string str)
        {
            Dictionary<string,string> result=new Dictionary<string, string>();
            result=JsonConvert.DeserializeObject<Dictionary<string,string>>(str);

            return result;
        }
    }
}
