using System;
using System.Collections.Generic;
using System.Text;

namespace BrainJam2020
{
    public struct CoOrdinate
    {
        public int First { get;  }
        public int Second { get; }
        public CoOrdinate(int first, int second)
        {
            First = first;
            Second = second;
        }

        public string ToString() => "" + First + " " + Second;
    }
}
