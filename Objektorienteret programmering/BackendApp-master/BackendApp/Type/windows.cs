using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Type
{
    public class windows : os, IOS
    {
        public windows(string userfullname) : base(userfullname)
        {

        }
        public string ShowOSType()
        {
            return $"welcome {UserFullName} to windows, running from backend!";
        }
    }
}
