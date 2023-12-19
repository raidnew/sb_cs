using System;
using System.Collections.Generic;

namespace Task3_10
{
    internal class Task1
    {
        public static void Main(string[] args)
        {
            
            
            Task1 test = new Task1();

            test.foundMin();

            test.isEven(12);

            test.isPrimeNumber(37);
            
            /*
            playGuessNumber gameGuess = new playGuessNumber();
            gameGuess.start();
            
            GameTwentyOne game = new GameTwentyOne();
            game.start();
            */
        }

        private bool isEven(int value)
        {
            return !Convert.ToBoolean(value & 1);
        }

        private bool isPrimeNumber(int value)
        {
            List<int> primeNumbers = new List<int>();
            primeNumbers.Add(2);
            bool foundDivisor = false;
            for (int  i = 2; i <= value; i++)
            {
                foundDivisor = false;
                for (int j = 0; j < primeNumbers.Count;j++)
                {
                    if (i % primeNumbers[j] == 0)
                    {
                        foundDivisor = true;
                        break;
                    }
                }
                if(!foundDivisor) primeNumbers.Add(i);
            }
            return !foundDivisor;
        }

        private void foundMin()
        {
            int foundMinValue = int.MaxValue;
            Random randomizer = new Random();
            
            for (int i = 0 ;i < 10; i++)
            {
                int rndValue = randomizer.Next(int.MinValue, int.MaxValue);
                //TODO request number from user
                foundMinValue = Math.Min(foundMinValue, rndValue);
            }
            
            Console.WriteLine($"Min value: {foundMinValue}");
        }
        
    }

    
    
    
}