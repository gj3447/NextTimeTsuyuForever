using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCopyLib.Module
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModuleAttribute : Attribute
    {
        PROCESS_TYPE process_type;

        public ModuleAttribute(PROCESS_TYPE process_type_)
        {
            process_type = process_type_;
        }
    }
}
