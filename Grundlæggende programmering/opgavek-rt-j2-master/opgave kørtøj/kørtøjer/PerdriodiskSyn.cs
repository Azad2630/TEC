using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave_kørtøj.kørtøjer
{
    internal class PerdriodiskSyn
    {
        public class PeriodiskSyn
        {
            public int SynInterval { get; }

            public PeriodiskSyn(int synInterval)
            {
                SynInterval = synInterval;
            }
        }
    }
}
