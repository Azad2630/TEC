using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave_kørtøj.animal
{
    using System;

    public class Cat : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("Meow!");
        }
    }
}
