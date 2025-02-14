using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AsyncCopyLib.Module;
namespace AsyncCopyLib.System
{
    public class ModuleCluster
    {
        //Search Process
        private ModuleSearchRead _search_read;
        private ModuleSearchWrite _search_write;

        //Pre Process
        private ModulePathSplitter _path_splitter;
        private ModuleCreateReadDirectory _create_read_dir;
        private ModuleCreateReadFile _create_read_file;

        //Process
        private ModuleRead _read;
        private ModuleWrite _write;

        //Post Process
        private ModuleSwapFile _swap_file;
        private ModuleDeleteWriteDirectory _delete_write_dir;
        private ModuleDeleteWriteFile _delete_write_file;

        //Stop Process
        private ModuleDeleteCreatedDirectory _delete_read_dir;
        private ModuleDeleteCreatedFile _delete_read_file;

        public IModule[] get_module_all { get { return new IModule[12] {
            _search_read,_search_write,
            _path_splitter,_create_read_dir,_create_read_file,
            _read,_write,
            _swap_file,_delete_write_dir,_delete_read_dir,
            _delete_read_dir,_delete_read_file};
            } }
        //Search Process
        public ModuleSearchRead get_search_read => _search_read;
        public ModuleSearchWrite get_search_write => _search_write;
        public IModule[] get_module_search_process { get { 
        return new IModule[2] {_search_read,_search_write }; 
            } }
        //Pre Process
        public ModulePathSplitter get_path_splitter => _path_splitter;
        public ModuleCreateReadDirectory get_create_read_dir => _create_read_dir;
        public ModuleCreateReadFile get_create_read_file => _create_read_file;
        public IModule[] get_module_pre_process { get {
        return new IModule[3] { _path_splitter, _create_read_dir, _create_read_file };
            } }
        //Process
        public ModuleRead get_read => _read;
        public ModuleWrite get_write => _write;
        public IModule[] get_module_process { get {
                return new IModule[2] { _read, _write };
            } }
        //Post Process
        public ModuleSwapFile get_swap_file => _swap_file;
        public ModuleDeleteWriteDirectory get_delete_write_dir => _delete_write_dir;
        public ModuleDeleteWriteFile get_delete_write_file => _delete_write_file;
        public IModule[] get_module_post_process { get {
            return new IModule[3] { _swap_file, _delete_write_dir, _delete_write_file }; 
            } }
        //Stop Process
        public ModuleDeleteCreatedDirectory get_delete_read_dir => _delete_read_dir;
        public ModuleDeleteCreatedFile get_delete_read_file => _delete_read_file;
        public IModule[] get_module_stop_process { get {
                return new IModule[2] { _delete_read_dir, _delete_read_file };
            } }
        public ModuleCluster()
        {
            _search_read       = new ModuleSearchRead();
            _search_write      = new ModuleSearchWrite();
            _path_splitter     = new ModulePathSplitter();
            _create_read_dir   = new ModuleCreateReadDirectory();
            _create_read_file  = new ModuleCreateReadFile();
            _read              = new ModuleRead();
            _write             = new ModuleWrite();
            _swap_file         = new ModuleSwapFile();
            _delete_write_dir  = new ModuleDeleteWriteDirectory();
            _delete_write_file = new ModuleDeleteWriteFile();
            _delete_read_dir   = new ModuleDeleteCreatedDirectory();
            _delete_read_file  = new ModuleDeleteCreatedFile();
        }
    }
}
