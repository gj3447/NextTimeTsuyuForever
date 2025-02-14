using AsyncCopyLib.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCopyLib.Task
{
    public class TaskWrite : Task
    {
        public int index { get; set; }
        public byte[] data { get; set; }

        public TaskWrite (string path_, int index_, byte[] data_)
        {
            path  = path_;
            index = index_;
            data  = data_;
        }
        public bool h_write(Setting setting)
        {

        }
    }
}
