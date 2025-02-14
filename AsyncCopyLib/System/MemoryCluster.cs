using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncCopyLib.Task;
namespace AsyncCopyLib.System
{
    public class MemoryCluster
    {
        private ConcurrentQueue<string>    _search_read_path_queue;
        private ConcurrentQueue<string>    _search_write_path_queue;


        private ConcurrentQueue<TaskRead>  _task_read_queue;
        private ConcurrentQueue<TaskWrite> _task_write_queue;

        private ConcurrentQueue<string>    _read_path_file_queue;        
        private ConcurrentQueue<string>    _write_path_file_queue;         
        private ConcurrentQueue<string>    _read_path_dir_queue;         
        private ConcurrentQueue<string>    _write_path_dir_queue;       
        private ConcurrentQueue<string>    _readwrite_path_file_queue; 
        private ConcurrentQueue<string>    _readwrite_path_dir_queue;  
                                           
        private ConcurrentQueue<string>    _create_path_file_queue;    
        private ConcurrentQueue<string>    _create_path_dir_queue;

        private ConcurrentDictionary<string, PATH_STATE> _path_state_dic;

        private long _total_bytes;
        private long _using_bytes;
        private long _worked_bytes;

        private object _search_byte_lock = new object();
        private object _using_byte_lock  = new object();
        private object _worked_byte_lock = new object();

        public ConcurrentQueue<string> get_search_read_path_queue    => _search_read_path_queue;
        public ConcurrentQueue<string> get_search_write_path_queue   => _search_write_path_queue;
        public ConcurrentQueue<TaskRead>  get_task_read_queue        => _task_read_queue;
        public ConcurrentQueue<TaskWrite> get_task_write_queue       => _task_write_queue;
        public ConcurrentQueue<string> get_read_path_file_queue      => _read_path_file_queue;
        public ConcurrentQueue<string> get_write_path_file_queue     => _write_path_file_queue;
        public ConcurrentQueue<string> get_read_path_dir_queue       => _read_path_dir_queue;
        public ConcurrentQueue<string> get_write_path_dir_queue      => _write_path_dir_queue;
        public ConcurrentQueue<string> get_readwrite_path_file_queue => _readwrite_path_file_queue;
        public ConcurrentQueue<string> get_readwrite_path_dir_queue  => _readwrite_path_dir_queue;
        public ConcurrentQueue<string> get_create_path_file_queue    => _create_path_file_queue;
        public ConcurrentQueue<string> get_create_path_dir_queue     => _create_path_dir_queue;
        public ConcurrentDictionary<string, PATH_STATE> get_path_state_dic => _path_state_dic;
        public void h_search_byte(long byte_size)
        {
            lock(_search_byte_lock)
            {
                _total_bytes += byte_size;
            }
        }
        public void h_using_byte(long byte_size)
        {
            lock(_using_byte_lock)
            {
                _using_bytes += byte_size;
            }
        }
        public void h_worked_byte(long byte_size)
        {
            lock(_worked_byte_lock)
            {
                _using_bytes -= byte_size;
                _worked_bytes += byte_size;
            }
        }
        public MemoryCluster()
        {
            _total_bytes  = 0;
            _using_bytes  = 0;
            _worked_bytes = 0;

            _search_read_path_queue    = new ConcurrentQueue<string>();
            _search_write_path_queue   = new ConcurrentQueue<string>();

            _task_read_queue           = new ConcurrentQueue<TaskRead>();
            _task_write_queue          = new ConcurrentQueue<TaskWrite>();
            _read_path_file_queue      = new ConcurrentQueue<string>();
            _write_path_file_queue     = new ConcurrentQueue<string>();
            _read_path_dir_queue       = new ConcurrentQueue<string>();
            _write_path_dir_queue      = new ConcurrentQueue<string>();
            _readwrite_path_file_queue = new ConcurrentQueue<string>();
            _readwrite_path_dir_queue  = new ConcurrentQueue<string>();
            _create_path_file_queue    = new ConcurrentQueue<string>();
            _create_path_dir_queue     = new ConcurrentQueue<string>();

            _path_state_dic            = new ConcurrentDictionary<string, PATH_STATE>();
        }
    }
}
