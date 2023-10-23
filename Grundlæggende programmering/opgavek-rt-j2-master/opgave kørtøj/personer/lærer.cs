using opgave_kørtøj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave_kørtøj.Personer
{
    using System;
    public class Laerer : Person
    {
        public Laerer(string name) : base(name)
        {
        }

        public override void ShowMyIdentity()
        {
            Console.WriteLine("Jeg er en lærer.");
        }
    }
}
