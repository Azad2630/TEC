using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opgave_kørtøj.kørtøjer
{
    public class Koretoj
    {
        public string Mark { get; }
        public string Model { get; }
        public int BagagerumVolumelKubikCm { get; }
        public int PedalStorrelseCm { get; }
        public const int _synInterval = 2;

        public Koretoj(string mark, string model, int bagagerumVolumen, int pedalStorrelse)
        {
            Mark = mark;
            Model = model;
            BagagerumVolumelKubikCm = bagagerumVolumen;
            PedalStorrelseCm = pedalStorrelse;
        }
    }
}
