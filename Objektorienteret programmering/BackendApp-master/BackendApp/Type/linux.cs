using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Type
{
    public class linux : os, IOS
    {
        public linux(string userfullname) : base(userfullname)
        {

        }
        public string ShowOSType()
        {
            return $"welcome {UserFullName} to linux, running from backend!";
        }
    }
}
