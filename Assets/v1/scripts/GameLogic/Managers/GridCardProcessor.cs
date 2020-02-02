using System;
using System.Collections.Generic;
using System.Threading;


namespace BrainJam2020
{
    class GridCardProcessor
    {
        #region Methods

        //public

        public Dictionary<CoOrdinate, Card> GetCards(GridBalanceManager gridBalanceManager)
        {
            //called by new Grid().ResetCardBalance();
            GridBalanceManagerV = gridBalanceManager;
            GridSize = gridBalanceManager.Size;
            InitialNumbersOfOperators = GridBalanceManagerV.GetInitialNumbersOfOperators();
            InitialNumbersOfPoints = GridBalanceManagerV.GetInitialNumbersOfPoints();
            /*Console.WriteLine("process.getcard" + InitialNumbersOfOperators.Count+" "+InitialNumbersOfPoints.Count);
            foreach (var VARIABLE in InitialNumbersOfPoints)
            {
                Console.WriteLine(VARIABLE.Key+" "+VARIABLE.Value);
            }*/
            MapCardToCoOrdinate();
            //Console.WriteLine("process.getcard"+CardMappedByCoOrdinated.Count);
            return CardMappedByCoOrdinated;
        }

        //private
        private int[] CreatePoints()
        {
            //called by GridCardProcessor().CreateShuffledPoints()
            int[] points=new int[GridSize*GridSize];
            int index = 0;
            foreach (var element in InitialNumbersOfPoints)
            {
                for(int i=1; i<= element.Value && index<GridSize*GridSize; i++)points[index++]= element.Key;
            }
            return points;
        }
        private string[] CreateOperators()
        {
            //called by GridCardProcessor().CreateShuffledOperators()
            string[] _operators = new string[GridSize * GridSize];
            int index = 0;
            foreach (var element in InitialNumbersOfOperators)
            {
                for (int i = 1; i <= element.Value && index<GridSize*GridSize; i++) _operators[index++] = element.Key;
            }
            return _operators;
        }
        private T[] Shuffle<T>(T[] array)
        {
            // called by GridCardProcessor().CreateShuffledPoints() & CreateShuffledOperators

            Random random =new Random();
            for (int i = 0; i < GridSize * GridSize; i++)
            {
                var swapIndex = random.Next(0,GridSize*GridSize-1);
                var temporary = array[i];
                array[i] = array[swapIndex];
                array[swapIndex] = temporary;
            }
            for (int i = 0; i < GridSize * GridSize; i++)
            {
                var swapIndex = random.Next(0, GridSize * GridSize - 1);
                var temporary = array[i];
                array[i] = array[swapIndex];
                array[swapIndex] = temporary;
            }
            return array;
        }
        private int[] CreateShuffledPoints()
        {
            // called by  GridCardProcessor().CreateCards()
            int[] points = CreatePoints();
            //Console.WriteLine("process.createShuffledPoints "+points.Length);
            points = Shuffle<int>(points);
            return points;
        }
        private string[] CreateShuffledOperators()
        {
            // called by  GridCardProcessor().CreateCards()
            string[] _operators = CreateOperators();
            _operators = Shuffle<string>(_operators);
            return _operators;
        }
        private Card[] CreateShuffledCards()
        {
            int[] shuffeledPoints = CreateShuffledPoints();
            string[] shuffledOperators = CreateShuffledOperators();
            //Console.WriteLine("process.createshuffledcards "+shuffeledPoints.Length);
            Card[] listCard=new Card[GridSize*GridSize];
            for (int i = 0; i < GridSize * GridSize; i++)
            {
                listCard[i]=new Card(shuffeledPoints[i], shuffledOperators[i]);
            }
            return listCard;
        }
        private void MapCardToCoOrdinate()
        {
            //called by GridCardProcessor().GetCards()
            Card[] cards = CreateShuffledCards();
            //Console.WriteLine("process.mapcardtocoordinate "+cards.Length);
            int cardIndex = 0;
            CardMappedByCoOrdinated=new Dictionary<CoOrdinate, Card>();
            for(int i=1; i<=GridSize; i++)
            for (int j = 1; j <= GridSize; j++)
            {
                CardMappedByCoOrdinated.Add(new CoOrdinate(i,j), cards[cardIndex++]);
            }
        }

        #endregion

        #region Variables

        private GridBalanceManager GridBalanceManagerV;
        private Dictionary<String, int> InitialNumbersOfOperators;
        private Dictionary<int, int> InitialNumbersOfPoints;
        private int GridSize;
        private Dictionary<CoOrdinate, Card> CardMappedByCoOrdinated;

        #endregion

    }

}
