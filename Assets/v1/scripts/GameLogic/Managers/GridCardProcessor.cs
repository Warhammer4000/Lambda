using System;
using System.Collections.Generic;
using System.Linq;
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
        private Stack<int> CreatePoints()
        {
            //called by GridCardProcessor().CreateShuffledPoints()
            int[] points=new int[GridSize*GridSize];
            int index = 0;
            foreach (var element in InitialNumbersOfPoints)
            {
                for(int i=1; i<= element.Value && index<GridSize*GridSize; i++)points[index++]= element.Key;
            }
            return CreateRandomStack(points);
        }
        private Stack<string> CreateOperators()
        {
            //called by GridCardProcessor().CreateShuffledOperators()
            string[] _operators = new string[GridSize * GridSize];
            int index = 0;
            foreach (var element in InitialNumbersOfOperators)
            {
                for (int i = 1; i <= element.Value && index<GridSize*GridSize; i++) _operators[index++] = element.Key;
            }
            return CreateRandomStack(_operators);
        }
        private Stack<T> CreateRandomStack<T>(T[] array)
        {
            
            Stack<T> randomStack=new Stack<T>();

            array.Shuffle();

            foreach (var item in array)
            {
                randomStack.Push(item);
            }

            return randomStack;
        }
      
        private Card[] CreateShuffledCards()
        {
            Stack<int> shuffeledPoints = CreatePoints();
            Stack<string> shuffledOperators = CreateOperators();
            //Console.WriteLine("process.createshuffledcards "+shuffeledPoints.Length);
            Card[] listCard =new Card[GridSize * GridSize];

           
            for (int i = 0; i < GridSize * GridSize; i++)
            {
                listCard[i]=new Card(shuffeledPoints.Pop(), shuffledOperators.Pop());
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
                cards[cardIndex].CoOrdinate = new CoOrdinate(i, j);
                CardMappedByCoOrdinated.Add(cards[cardIndex].CoOrdinate, cards[cardIndex]);
                
                cardIndex++;
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
