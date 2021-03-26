using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediff_Test
{
    class Owners
    {
        private Dictionary<string, string> _OwnerDic = new Dictionary<string, string>();
        public void Add(System.IO.StreamWriter sw, Dictionary<string, string> OwnersDic=null)
        {
            if (OwnersDic == null)
            {
                sw.WriteLine("[Warning]:\t Dictionary is null");
                OwnersDic = new Dictionary<string, string>() { { "Input.txt", "Randy" }, { "Code.py", "Stan" }, { "Output.txt", "Randy" } };
            }
            _OwnerDic = OwnersDic;
        }
        public Dictionary<string, List<string>> Group_By_Owners()
        {
            Dictionary<string, List<string>> grouplstdic = new Dictionary<string, List<string>>();
            foreach (string filename in _OwnerDic.Keys)
            {
                if (!grouplstdic.ContainsKey(_OwnerDic[filename]))
                    grouplstdic.Add(_OwnerDic[filename], new List<string>());
                grouplstdic[_OwnerDic[filename]].Add(filename);
            }
            return grouplstdic;
        }
    }
}
