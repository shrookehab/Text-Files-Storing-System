using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Project
{
    class FileInfo
    {
        public string FileName;
        public string FilePath;
        public Dictionary<string, List<string>> CategoryList;

        public FileInfo(string FileName, string FilePath)
        {
            this.FileName = FileName;
            this.FilePath = FilePath;
            CategoryList = new Dictionary<string, List<string>>();
        }
    }
}
