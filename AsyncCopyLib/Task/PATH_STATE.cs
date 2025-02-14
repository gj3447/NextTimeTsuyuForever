using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCopyLib.Task
{
    [Flags]
    public enum PATH_STATE
    {
        NULL = 0,

        READ_FILE = 1,
        READ_DIRECTORY = 2,

        WRITE_FILE = 4,
        WRITE_DIRECTORY = 8,
    }
}
