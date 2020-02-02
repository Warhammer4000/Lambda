using System;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

namespace BrainJam2020
{
    public class GameManager:MonoBehaviour
    {

        public static GameManager Instance;

        #region VARIABLES

        public Player FirstPlayer { get; private set; }
        public Player SecondPlayer { get; private set; }
        public Grid _Grid { get; set; }
        public int MarginalScore = 31;

        #endregion

        [SerializeField] private CardGridManager CardGridManager;

        public SoreController ScoreControllerP1;
        public SoreController ScoreControllerP2;



        void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            Initialize();
        }



        private void Initialize(int gridSize = 10)
        {
            _Grid = new Grid(gridSize);
            FirstPlayer = new Player("Aminul"){PlayerType = Player.PlayerEnum.Player1};
            SecondPlayer = new Player("Kabir"){PlayerType = Player.PlayerEnum.Player2};
            ScoreControllerP1.InitializePlayer(FirstPlayer);
            ScoreControllerP2.InitializePlayer(SecondPlayer);

            CardGridManager.CreateGrid(_Grid);
        }

        

       

        
        #region METHODS
        //public 

        public void StartPlay(int marginalScore=31)
        {
            /*MarginalScore = marginalScore;
            int Turn = 1;
            int[] ins;
            string inps;
            bool willIterate = true;
            while (_Grid.CurrentNumberOfCards > 0)
            {

                //willIterate = (Turn % 2 == 1) ? MakeMove(FirstPlayer) : MakeMove(SecondPlayer);
                if(willIterate)return;
                if (GetTheWinner() != 0)
                {
                    if (GetTheWinner() == 1)
                    {
                        wl(FirstPlayer.Name+" WON  !!!");
                    }
                    else
                    {
                        wl(SecondPlayer.Name+" WON  !!!");
                    }

                    return;
                }
                Turn++;
            }*/
        }
        public void ResetGrid(Grid grid) => _Grid = grid;

        //private
        public void MakeMove(Player player,CoOrdinate coOrdinate)
        {
            var card = _Grid.PopCardAt(coOrdinate);
            if (card.Operator == StringResources.WildCard)
            {
                WildCardPicker.Instance.RegisterPlayerAndCard(player,card);
                return;
            }


            player.ReceiveCard(card);
        
        }
       
        private void StandOff(Player player)
        {
            /*Player LastPlayer = (player == FirstPlayer ? SecondPlayer : FirstPlayer);
            if (MakeMove(LastPlayer, true))
            {
                if (MakeMove(LastPlayer, true))
                {
                    if (MakeMove(LastPlayer, true))
                    {
                        Console.WriteLine(player.Name +"  Won !!!");
                        return;
                    }
                }
            }*/
        }
        private int GetTheWinner()
        {
            if (FirstPlayer.LambdaCards >= 3) /////////////////////
                return 1;
            else if ( SecondPlayer.LambdaCards >= 3)
                return 2;
            else return 0;
        }

        #endregion


        #region ReadWrite
        private void printGrid()
        {
            Dictionary<string, int> _ops = _Grid.GetOperatorsCount();
            Dictionary<CoOrdinate, Card> cardsWithCo = _Grid.GetCards();
            Console.WriteLine("Score ----  "+"Margin "+ MarginalScore+ "  " + FirstPlayer.Name +" => " + FirstPlayer.Score.Value + "/" + FirstPlayer.LambdaCards +
                              " ### "+SecondPlayer.Name + " => " + SecondPlayer.Score.Value + "/" + SecondPlayer.LambdaCards);
            wl("");
            w("CARDS --- ");
            foreach (var element in _ops)
            {
                w(element.Key + "=>" + element.Value + " ### ");
            }

            wl("\n");
            for (int i = 1; i <= _Grid.Size; i++)
            {
                for (int j = 1; j <= _Grid.Size; j++)
                {
                    Console.Write("" + i + "," + j + "=>");
                    CoOrdinate coo = new CoOrdinate(i, j);
                    if (cardsWithCo.ContainsKey(coo)) Console.Write(cardsWithCo[coo].Point.Value + "       ");
                    else
                    {
                        Console.Write("blank    ");
                    }
                }

                Console.WriteLine();
            }


        }
        static void wl(String txt) => Console.WriteLine(txt);
        static void wl(double num) => Console.WriteLine("" + num);
        static void w(String txt) => Console.Write(txt);
        private void writeln<T>(T a) => Console.WriteLine(a);
        private long[] readLongLine() => Console.ReadLine().Split().Select(long.Parse).ToArray();
        private int[] readIntLine() => Console.ReadLine().Split().Select(int.Parse).ToArray();
        private long readLong() => Convert.ToInt64(Console.ReadLine());
        private int readInt() => Convert.ToInt32(Console.ReadLine());
        #endregion

    }
}