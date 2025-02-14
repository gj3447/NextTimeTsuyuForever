using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncCopyLib.Task;
using System.Collections.Concurrent;

namespace AsyncCopyLib.System
{
    public class PullingCluster
    {
        private ConcurrentQueue<TaskRead>   _task_read_queue;
        private ConcurrentQueue<TaskWrite> _task_write_queue;

        public TaskRead pull_task_read(string path_, int index_)
        { 
            if(_task_read_queue.TryDequeue(out TaskRead tr))
            {
                tr.path  = path_;
                tr.index = index_;
                return tr;
            }
            else
            {
                return new TaskRead(path_,index_);
            }    
        }
        public TaskWrite pull_task_write(string path_, int index_, byte[] data_)
        {
            if(_task_write_queue.TryDequeue(out TaskWrite tw))
            {
                tw.path  = path_;
                tw.index = index_;
                tw.data  = data_;
                return tw;
            }
            else
            {
                return new TaskWrite(path_, index_, data_);
            }
        }
        public void free_task_read(TaskRead tr)
        {

        }
        public void free_task_write(TaskWrite tw)
        {

        }

        public PullingCluster()
        {
            _task_read_queue = new ConcurrentQueue<TaskRead>();
            _task_write_queue = new ConcurrentQueue<TaskWrite>();
        }
    }
}
