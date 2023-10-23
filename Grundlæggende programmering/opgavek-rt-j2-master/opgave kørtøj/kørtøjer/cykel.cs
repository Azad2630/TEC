using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave_kørtøj.kørtøjer
{
    internal class cykel
    {
        public class Cykel : Koretoj
        {
            public Cykel(string mark, string model, int bagagerumVolumen, int pedalStorrelse)
                : base(mark, model, bagagerumVolumen, pedalStorrelse)
            {
                // Cykel-specifikke constructor handling
            }
        }
    }
}
