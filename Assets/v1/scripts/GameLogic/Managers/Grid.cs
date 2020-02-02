using System;
using System.Collections.Generic;
using System.Threading;
using DTD.Calculator.Core;

namespace BrainJam2020
{
    [Serializable]
    public class Grid
    {
        public Grid(int size=10)
        {
            Size = size;
            gridBalanceManagerV=new GridBalanceManager(size);
            ResetCardBalance();
        }


        #region VARIABLES
        //public 
        public int Size { get; private set; }
        public int CurrentNumberOfCards { get; private set; }


        //private
        private Dictionary<String, int> OperatorCount = new Dictionary<string, int>();
        private Dictionary<CoOrdinate, Card> Cards = null;
        private GridCardProcessor gridCardProcessorV=new GridCardProcessor();
        private GridBalanceManager gridBalanceManagerV;

        #endregion


        #region METHODS

        //public
        public Card PopCardAt(int row, int column)
        {
            return PopCardAt(new CoOrdinate(row, column));

        }
        public Card PopCardAt(CoOrdinate co)
        {
            if (Cards.ContainsKey(co))
            {
                var Return = Cards[co];
                DeleteCardAt(co);
                return Return;
            }
            return default;
        }
        public void ResizeGrid(int size)
        {
            Size = size;
            gridBalanceManagerV=new GridBalanceManager(Size);
            ResetCardBalance();
        }
        public void ResetCardBalance(int numberOfLambda = 5,Dictionary<int, int> percentageOfPoints=null, Dictionary<string, int> percantageOfOperators=null)
        {

            gridBalanceManagerV.ReSetConfigurations(numberOfLambda,percantageOfOperators, percentageOfPoints);
            OperatorCount = gridBalanceManagerV.GetInitialNumbersOfOperators();
            Cards = gridCardProcessorV.GetCards(gridBalanceManagerV);
            //Console.WriteLine("grid.resetcardbalance "+Cards.Count);
            CurrentNumberOfCards = Size * Size;
        }
        public Dictionary<CoOrdinate, Card> GetCards() => Cards;
        public Dictionary<String, int> GetOperatorsCount() => OperatorCount==null?default:OperatorCount;
        
        //private
        private void DeleteCardAt(CoOrdinate index)
        {
            if (Cards.ContainsKey(index))
            {
                OperatorCount[Cards[index].Operator] -= 1;
                Cards.Remove(index);
                CurrentNumberOfCards -= 1;
            }
        }
        private RealInt Calculate(String operation, RealInt Score, Card card) => OperationFactory<RealInt>.Instance.GetOperation(operation).Operate(Score, card.Point);

        #endregion

    }
}

