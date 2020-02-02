using System;
using System.Collections.Generic;
using System.Text;

namespace BrainJam2020
{
    struct Card
    {
        public Card(int point, String _operator)
        {
            Point = new RealInt(point);
            Operator = _operator;
        
        }

        #region VARIABLES
        //public
        
        //private
        public RealInt Point { get; private set; }
        public String Operator { get; private set; }
        #endregion


        #region METHODS
        //public
        public void ResetOperator(String _operator) => Operator = (Operator == "w") ? _operator : Operator;
        public int GetPointInt32() => Point.Value;
        public string ToString() => "" + Point.ToString() + " " + Operator;

        #endregion

    }
}
