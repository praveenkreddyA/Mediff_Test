using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediff_Test
{
    class DirectoryProgram
    {
        string _path=null;
        public DirectoryProgram(string path)
        {
            _path = path;
        }

        public void cd(string mpath)
        {
            if(mpath.Contains(".."))
            {
                List<string> p = _path.Split('/').ToList();
                p.Remove("");
                int len = p.Count;
                p[len - 1] = mpath.Replace("../", "");
                _path = string.Join("/", p);
            }
        }
        public string getCurrentPath()
        {
            return _path;
        }
    }
}
