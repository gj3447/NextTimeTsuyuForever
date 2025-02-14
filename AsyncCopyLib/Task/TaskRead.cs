using AsyncCopyLib.System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCopyLib.Task
{
    public class TaskRead : Task
    {
        public int index { get; set; }

        public TaskRead(string path_, int index_)
        {
            path  = path_;
            index = index_;
        }
        public byte[] h_read(Setting setting)
        {

        }
        public static TaskRead[] h_file2task_read(FileInfo file ,PullingCluster pullings, Setting setting)
        {
        }
    }
}
