using AsyncCopyLib.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCopyLib.Module
{
    [Module(PROCESS_TYPE.STOP_PROCESS)]
    public class ModuleDeleteCreatedDirectory : IModule
    {
        public Action h_get_action(MemoryCluster memories, PullingCluster pullings, Setting setting)
        {
            throw new NotImplementedException();
        }

        public MODULE_STATE h_get_state(MemoryCluster memories, Setting setting)
        {
            throw new NotImplementedException();
        }

        public Action h_try_get_action(MemoryCluster memories, PullingCluster pullings, Setting setting)
        {
            throw new NotImplementedException();
        }
    }
}
