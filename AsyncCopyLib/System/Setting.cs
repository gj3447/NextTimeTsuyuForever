using AsyncCopyLib.LoadBalancer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCopyLib.System
{
    public class Setting
    {
        private string _read_path;
        private string _write_path;

        private long _chunk_size;
        private long _memory_max;
        private int _worker_count;

        private LOAD_BALANCER_TYPE _load_balancer_type;

        public string get_read_path  => _read_path;
        public string get_write_path => _write_path;
        public long get_chunk_size   => _chunk_size;
        public long get_memory_max   => _memory_max;
        public int get_worker_count  => _worker_count;
        public LOAD_BALANCER_TYPE get_load_balancer_type => _load_balancer_type;

        public string h_read_path(string path)
        {
            return Path.Combine(_read_path, path);
        }
        public string h_write_path(string path)
        {
            return Path.Combine(_write_path, path);
        }
        public string h_relative_path(string path)
        {
            if(path.StartsWith(_read_path,StringComparison.OrdinalIgnoreCase))
            {
                return StaticFunction.h_relative_path(_read_path,  path);
            }
            else if(path.StartsWith(_write_path,StringComparison.OrdinalIgnoreCase))
            {
                return StaticFunction.h_relative_path(_write_path, path);
            }
            else
            {
                throw new Exception($"relative path error, read_path = {_read_path},write_path = {_write_path},base_path = {path}");
            }
        }
        
    }
}
