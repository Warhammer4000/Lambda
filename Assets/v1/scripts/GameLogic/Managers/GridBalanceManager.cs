using System;
using System.Collections.Generic;

namespace BrainJam2020
{
    class GridBalanceManager
    {
        public GridBalanceManager(int size = 10)
        {
            Size = size;
        }

        #region Methods

        //public
        public void ReSetConfigurations( int numberOfLambda = 5, Dictionary<String, int> percentageOfOperators = null, Dictionary<int, int> percentageOfPoints = null)
        {
            // called by GridCardProcessor().GetCards()
            CalculateInitialNumberOfOperators(numberOfLambda, percentageOfOperators);
            CalculateInitialNumberOfEachPoint(percentageOfPoints);
        }
        public Dictionary<String, int> GetInitialNumbersOfOperators()
        {
            //called by GridCardProcessor().GetCards();
            return InitialNumberOfOperators;
        } 
        public Dictionary<int,int> GetInitialNumbersOfPoints()
        {
            //called by GridCardProcessor().GetCards();
            return InitialNumberOfPoint;
        }

        //private
        private int getRandomValueOfPercentageRange(int size, int percentage, int errorOfPercentage)
            {
                //called by CalculateInitialNumberOfEachPoint() & CalculateInitialNumberOfOperators();

                int min = size * (percentage - errorOfPercentage) / 100;
                int max = size * (percentage + errorOfPercentage) / 100;
                Random random = new Random();
                return random.Next(min, max);
            }
        private void CalculateInitialNumberOfOperators(int numberOfLambda = 5, Dictionary<String, int> percentageOfOperators = null)
        {
            // called by  GridBalanceManager.ReSetConfigurations()

            InitialNumberOfOperators.Clear();
            InitialNumberOfOperators.Add(StringResources.Lambda, numberOfLambda);
            if (percentageOfOperators == null)
            {
                InitialNumberOfOperators.Add(StringResources.WildCard, getRandomValueOfPercentageRange(Size * Size, 5, 2));
                InitialNumberOfOperators.Add(StringResources.Divide, getRandomValueOfPercentageRange(Size * Size, 5, 2));
                InitialNumberOfOperators.Add(StringResources.Multiply, getRandomValueOfPercentageRange(Size * Size, 5, 2));
                //InitialNumberOfOperators.Add("p", getRandomValueOfPercentageRange(Size * Size, 4, 1));
                InitialNumberOfOperators.Add(StringResources.Minus, getRandomValueOfPercentageRange(Size * Size, 35, 5));
                #region restOne
                InitialNumberOfOperators.Add(StringResources.Plus, Size * Size - InitialNumberOfOperators[StringResources.Divide]
                                                 - InitialNumberOfOperators[StringResources.Multiply]
                                                                - InitialNumberOfOperators[StringResources.Minus] - InitialNumberOfOperators[StringResources.WildCard]
                                                                - InitialNumberOfOperators[StringResources.Lambda]);
                #endregion
            }
            else
            {
                int sumOfEntey = 0;
                int nextEntry;
                foreach (var elements in percentageOfOperators)
                {
                    nextEntry = getRandomValueOfPercentageRange(Size * Size, elements.Value, 2);
                    sumOfEntey += nextEntry;
                    InitialNumberOfOperators.Add(elements.Key, nextEntry);
                }

                while (sumOfEntey < Size * Size)
                {
                    foreach (var element in percentageOfOperators)
                    {
                        if(element.Key==StringResources.Lambda)continue;
                        InitialNumberOfOperators[element.Key] += 1;
                        sumOfEntey += 1;
                        if (sumOfEntey >= Size * Size) break;
                    }
                }
                while (sumOfEntey > Size * Size)
                {
                    foreach (var element in percentageOfOperators)
                    {
                        if (element.Key == StringResources.Lambda) continue;
                        InitialNumberOfOperators[element.Key] -= 1;
                        sumOfEntey -= 1;
                        if (sumOfEntey <= Size * Size) break;
                    }
                }
            }
        }
        private void CalculateInitialNumberOfEachPoint(Dictionary<int, int> percentageOfEachPoint = null)
        {
            // called by  GridBalanceManager.ReSetConfigurations()

            InitialNumberOfPoint.Clear();
            if (percentageOfEachPoint == null)
            {
                InitialNumberOfPoint.Add(-5, getRandomValueOfPercentageRange(Size*Size, 8,2));
                InitialNumberOfPoint.Add(5, getRandomValueOfPercentageRange(Size * Size, 8,2));
                InitialNumberOfPoint.Add(-4, getRandomValueOfPercentageRange(Size * Size, 8,2));
                InitialNumberOfPoint.Add(4, getRandomValueOfPercentageRange(Size * Size, 8,2));
                InitialNumberOfPoint.Add(-3, getRandomValueOfPercentageRange(Size * Size, 8,2));
                InitialNumberOfPoint.Add(3, getRandomValueOfPercentageRange(Size * Size, 8,2));
                InitialNumberOfPoint.Add(-2, getRandomValueOfPercentageRange(Size * Size, 8,2));
                InitialNumberOfPoint.Add(2, getRandomValueOfPercentageRange(Size * Size, 8,2));
                InitialNumberOfPoint.Add(-1, getRandomValueOfPercentageRange(Size * Size, 8, 2));
                InitialNumberOfPoint.Add(1, Size*Size-InitialNumberOfPoint[-5]
                                                      - InitialNumberOfPoint[5]
                                                      - InitialNumberOfPoint[-4]
                                                      - InitialNumberOfPoint[4]
                                                      - InitialNumberOfPoint[-3]
                                                      - InitialNumberOfPoint[3]
                                                      - InitialNumberOfPoint[-2]
                                                      - InitialNumberOfPoint[2]
                                                      - InitialNumberOfPoint[-1]);
            }

            else
            {
                int sumOfEntry = 0;
                int nextEntry;
                // enter numbers with randomized error
                foreach (var element in percentageOfEachPoint)
                {
                    nextEntry = getRandomValueOfPercentageRange(Size * Size, element.Value, 2);
                    sumOfEntry += nextEntry;
                    InitialNumberOfPoint.Add(element.Key, nextEntry);
                }
                // if entry is greater than size then remove
                while (sumOfEntry < Size * Size)
                {
                    foreach (var element in percentageOfEachPoint)
                    {
                        InitialNumberOfPoint[element.Key] += 1;
                        sumOfEntry += 1;
                        if (sumOfEntry >= Size * Size) break;
                    }
                }
                // if entry is less than size then add 
                while (sumOfEntry > Size * Size)
                {
                    foreach (var element in percentageOfEachPoint)
                    {
                        InitialNumberOfPoint[element.Key] -= 1;
                        sumOfEntry -= 1;
                        if (sumOfEntry <= Size * Size) break;
                    }
                }
            }
        }

        #endregion

        #region Variables
        //public
        public int Size { get; set; }
        //private
        private int MinPoint { get; set; }
        private int MaxPoint { get; set; }
        private int AverageNumberOfEachPoint { get; set; }
        private Dictionary<String, int> InitialNumberOfOperators=new Dictionary<string, int>();
        private Dictionary<int, int> InitialNumberOfPoint=new Dictionary<int, int>();
        #endregion

    }

}

/*
int sumOfEntry = 0;
int nextEntry;
int averagePercentageOfNumbers = Size * Size / 10;
for (int i = -5, index = 0; i <= 5; i++)
{
if (i == 0) continue;
nextEntry = getRandomValueOfPercentageRange(Size* Size, averagePercentageOfNumbers, 2);
sumOfEntry += nextEntry;
InitialNumberOfPoint.Add(i, nextEntry);
}

// if entry is greater than size then remove
while (sumOfEntry<Size* Size)
{
//Console.WriteLine("hi from balancemanager.CalculateInitialPoint");
foreach (var el in InitialNumberOfOperators)
{
    Console.WriteLine(el.Key+" "+el.Value);
}

foreach (var element in InitialNumberOfPoint)
{
    Console.WriteLine(element.Key+" "+element.Value);
}
foreach (var element in InitialNumberOfPoint)
{
    Console.WriteLine("hi");
    InitialNumberOfPoint[element.Key] += 1;
    sumOfEntry += 1;
    if (sumOfEntry >= Size* Size) break;
}
}
// if entry is less than size then add 
while (sumOfEntry > Size* Size)
{
foreach (var element in percentageOfEachPoint)
{
    InitialNumberOfPoint[element.Key] -= 1;
    sumOfEntry -= 1;
    if (sumOfEntry <= Size* Size) break;
}
}*/