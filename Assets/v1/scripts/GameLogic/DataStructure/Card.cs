using System;
using System.Collections.Generic;
using System.Text;

namespace BrainJam2020
{
    public struct Card
    {
        #region VARIABLES
        //public

        //private
        public RealInt Point { get; private set; }
        public string Operator { get; private set; }
        public CoOrdinate CoOrdinate { get; set; }
        #endregion

        public Card(int point, string _operator)
        {
            Point = new RealInt(point);
            Operator = _operator;
            CoOrdinate=new CoOrdinate();
           
        }

       


        #region METHODS
        //public
        public void ResetOperator(String _operator) => Operator = (Operator == StringResources.WildCard) ? _operator : Operator;
       

        #endregion

    }
}
