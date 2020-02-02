using System.Collections.Generic;
using System.Text;
using DTD.Calculator.Core;
using Microsoft.VisualBasic;
using  System;

namespace BrainJam2020
{
    public class Player:IPlayer
    {
        public Player(string name="user", int score=0, int lambdaCards=0)
        {
            Name = name;
            Score=new RealInt(score);
            LambdaCards = lambdaCards;
        }

        #region METHODS
        //public
        public void ResetPlayer(string name = "user", int score = 0, int lambdaCards = 0)
        {
            Name = name;
            Score = new RealInt(score);
            LambdaCards = lambdaCards;
        }
        public void ReceiveCard(Card card)
        {
            if (card.Operator == StringResources.Lambda) LambdaCards += 1;
            else if (card.Operator == "p") return;
            else
            {
                /*IOperation<RealInt> _op = OperationFactory<RealInt>.Instance.GetOperation(card.Operator);
                _op.Operate(Score, card.Point);*/
                if (card.Operator == StringResources.Plus) Score=new RealInt(Score.Value+card.Point.Value);
                if (card.Operator == StringResources.Minus) Score = new RealInt(Score.Value - card.Point.Value);
                if (card.Operator == StringResources.Multiply) Score = new RealInt(Score.Value * card.Point.Value);
                if (card.Operator == StringResources.Divide) Score = new RealInt(Score.Value / card.Point.Value);
            }
                
        }

        #endregion


        #region VARIABLES
        public String Name { get; set; }
        public RealInt Score { get;  set; }
        public int LambdaCards { get;  set; }
        #endregion


        
    }
}
