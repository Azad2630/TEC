using opgave_kørtøj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave_kørtøj.Personer
{
    using System;

    public class Elev : Person
    {
        public Elev(string Name) : base(Name)
        {
            
        }

        public override void ShowMyIdentity()
        {
            Console.WriteLine("Jeg er en elev.");
        }
    }
}
