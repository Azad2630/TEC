using opgave_kørtøj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static opgave_kørtøj.kørtøjer.bil;

namespace opgave_kørtøj.kørtøjer
{
    internal class audi
    {
        public class Audi : Bil
        {
            public Audi(string mark, string model, int bagagerumVolumen, int pedalStorrelse)
                : base(mark, model, bagagerumVolumen, pedalStorrelse)
            {
                // Audi-specifikke constructor handling
            }
        }

    }
}
