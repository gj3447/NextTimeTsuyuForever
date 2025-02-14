using AsyncCopyLib.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCopyLib.Module
{
    public interface IModule
    {

        Action h_get_action(MemoryCluster memories, PullingCluster pullings, Setting setting);
        Action h_try_get_action(MemoryCluster memories,PullingCluster pullings, Setting setting);
        MODULE_STATE h_get_state(MemoryCluster memories, Setting setting);

    }
}
