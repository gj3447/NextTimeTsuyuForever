using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncCopyLib.System
{
    public static class StaticFunction
    {
        public static string h_path_write2temp(string write_path)
        {
            FileInfo fi = new FileInfo(write_path);
            string directoryPath = fi.DirectoryName;
            string fileName = fi.Name;
            string fixedFileName = $".{fi.Name}.next_time_tsuyu_forever";
            return $"{fi.DirectoryName}\\{fixedFileName}";
        }
        public static string h_path_temp2write(string temp_path)
        {
            FileInfo fi = new FileInfo(temp_path);
            string directoryPath = fi.DirectoryName;
            string fileName = fi.Name;
            if(fileName.StartsWith(".") && fileName.EndsWith(".next_time_tsuyu_forever"))
            {
                string originalFileName = fileName.Substring(1, fileName.Length - 27);
                return $"{directoryPath}\\{originalFileName}";
            }
            else
            {
                throw new ArgumentException("해당 파일은 변환된 파일이 아닙니다.");
            }
        }
        public static string h_relative_path(string basePath, string targetPath)
        {
            Uri baseUri = new Uri(basePath.EndsWith("\\") ? basePath : basePath + "\\");
            Uri targetUri = new Uri(targetPath);
            return Uri.UnescapeDataString(baseUri.MakeRelativeUri(targetUri).ToString()).Replace('/', Path.DirectorySeparatorChar);
        }
    }
}
