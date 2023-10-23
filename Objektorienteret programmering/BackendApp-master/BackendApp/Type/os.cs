using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Type
{
    public class os
    {
        public string UserFullName { get; set; }

        public os(string userFullName)
        {
            UserFullName = userFullName;
        }
    }
}
