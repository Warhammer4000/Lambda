using System;
using System.Collections.Generic;
using System.Text;

namespace BrainJam2020
{
    struct CoOrdinate
    {
        public int First { get; private set; }
        public int Second { get; private set; }
        public CoOrdinate(int first, int second)
        {
            First = first;
            Second = second;
        }

        public string ToString() => "" + First + " " + Second;
    }
}
