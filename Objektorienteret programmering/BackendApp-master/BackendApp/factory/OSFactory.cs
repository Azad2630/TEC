using BackendApp.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.factory
{
    public class OSFactory
    {
        public IOS indentify(string minUserFolder)
        {
            if (minUserFolder.Contains("c:"))
            {
                return new windows("Azad Akdeniz");
            }
            else if (minUserFolder.Contains('/'))
            {
                return new linux("Azad Akdeniz");
            }
            else
                return null;
        }
    }
}
