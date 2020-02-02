using System;
using System.Collections.Generic;
using System.Text;

namespace BrainJam2020
{
    public struct Card
    {
        public Card(int point, string _operator)
        {
            Point = new RealInt(point);
            Operator = _operator;
        
        }

        #region VARIABLES
        //public
        
        //private
        public RealInt Point { get; private set; }
        public string Operator { get; private set; }
        #endregion


        #region METHODS
        //public
        public void ResetOperator(String _operator) => Operator = (Operator == StringResources.WildCard) ? _operator : Operator;
        public int GetPointInt32() => Point.Value;
        public override string ToString() => "" + Point.ToString() + " " + Operator;

        #endregion

    }
}
