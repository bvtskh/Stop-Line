using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT.Business
{
    public class VersionHelper
    {
        public static string CheckVersion()
        {
            List<FileInfo> lstFile = new List<FileInfo>();
            var dirs = new DirectoryInfo(@"\\172.28.10.12\DX Center\68. Phần mềm chặn băng tải").GetDirectories().ToList();
            foreach (var iDir in dirs)
            {
                // lấy từng bài thi trong thư mục môn thi
                //var res = iDir.GetFiles("*.*", SearchOption.AllDirectories).ToList();
                // var iFiles = iDir.GetFiles("*.*", SearchOption.AllDirectories).Where(f => f.Name.Contains(FileName_RUN) && f.Name.ToLower().EndsWith("exe") && (!f.Name.Contains("vshost")));
                //lstFile.AddRange(iFiles);
                var fileExe = iDir.GetFiles($"SMT.exe", SearchOption.AllDirectories).ToList();
                lstFile.AddRange(fileExe);
            }
            lstFile = lstFile.OrderByDescending(i => i.CreationTime).ToList();
            return lstFile.FirstOrDefault().FullName.ToString();
        }
    }
}
