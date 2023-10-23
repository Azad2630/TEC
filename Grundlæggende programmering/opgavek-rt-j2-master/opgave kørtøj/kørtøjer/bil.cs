using opgave_kørtøj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave_kørtøj.kørtøjer
{
    internal class bil
    {
        public class Bil : Koretoj
        {
            public Bil(string mark, string model, int bagagerumVolumen, int pedalStorrelse)
                : base(mark, model, bagagerumVolumen, pedalStorrelse)
            {
                // Bil-specifikke constructor handling
            }
        }
    }
}
