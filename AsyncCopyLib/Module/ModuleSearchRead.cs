using AsyncCopyLib.System;
using AsyncCopyLib.Task;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCopyLib.Module
{
    [Module(PROCESS_TYPE.SEARCH_PROCESS)]
    public class ModuleSearchRead : IModule
    {
        public Action h_get_action(MemoryCluster memories, PullingCluster pullings, Setting setting)
        {
            if (memories.get_search_read_path_queue.TryDequeue(out string search_read_path))
            {
                return () => {
                    memories.get_path_state_dic.AddOrUpdate(
                        search_read_path, PATH_STATE.READ_DIRECTORY,
                    (key, oldValue) => oldValue | PATH_STATE.READ_DIRECTORY);
                    
                    DirectoryInfo di = new DirectoryInfo(setting.h_read_path(search_read_path));
                    foreach (FileInfo e in di.GetFiles())
                    {
                        string file_path = setting.h_relative_path(e.FullName);
                        memories.get_path_state_dic.AddOrUpdate(
                           file_path, PATH_STATE.READ_FILE,
                           (key, oldValue) => oldValue | PATH_STATE.READ_FILE);
                    }
                    foreach (DirectoryInfo e in di.GetDirectories())
                    {
                        string dir_path = setting.h_relative_path(e.FullName);
                        memories.get_search_read_path_queue.Enqueue(dir_path);
                    }
                };
            }
            else
            {
                return null;
            }
        }

        public MODULE_STATE h_get_state(MemoryCluster memories, Setting setting)
        {
            if (memories.get_search_read_path_queue.Count > 0)
            {
                return MODULE_STATE.WORK;
            }
            else
            {
                return MODULE_STATE.END;
            }
        }

        public Action h_try_get_action(MemoryCluster memories, PullingCluster pullings, Setting setting)
        {
            if(h_get_state(memories, setting) == MODULE_STATE.WORK)
            {
                return h_get_action(memories, pullings, setting);
            }
            else
            {
                return null;
            }
        }
    }
}
