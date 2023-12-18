using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;

namespace Task3_10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            
            Program test = new Program();

            //test.foundMin();

            //test.isEven(12);

            //test.isPrimeNumber(37);

            /*
            playGuessNumber gameGuess = new playGuessNumber();
            gameGuess.start();
            */

            /*
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

    class playGuessNumber
    {
        int getMaxNumber()
        {
            int maxNumber = 0;
            while (maxNumber <= 0)
            {
                try
                {
                    Console.Write("Input max value: ");
                    maxNumber = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid number. Please try again.");
                }
            }
            return maxNumber;
        }

        bool checkNumber(uint hiddenNumber, string inputString)
        {
            try
            {
                uint number = uint.Parse(inputString);
                if (number == hiddenNumber)
                {
                    return true;
                }
                else if (number < hiddenNumber)
                {
                    Console.WriteLine("Hidden number more");
                }
                else if (number > hiddenNumber)
                {
                    Console.WriteLine("Hidden number less");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Invalid input");
            }
            return false;
        }

        void throwGame(uint hiddenNumber)
        {
            Console.WriteLine($"Hidden numer is: {hiddenNumber}");
        }

        public void start()
        {
            int max = getMaxNumber();
            uint hiddenNumber = (uint)new Random().Next(max);
            bool isPlaying = true;
            while (isPlaying)
            {
                Console.Write("Try guess number: ");
                string inputString = Console.ReadLine();
                if (inputString == "")
                {
                    isPlaying = false;
                    throwGame(hiddenNumber);
                }
                else
                {
                    if (checkNumber(hiddenNumber, inputString))
                    {
                        Console.WriteLine("You win!");
                        isPlaying = false;
                    }
                }
            }
            Console.WriteLine("End game");
        }
    }
    
    class GameTwentyOne
    {
        private Dictionary<string, uint> cards;
        
        void initCardsList()
        {
            this.cards = new Dictionary<string, uint>();
                
            this.cards.Add("2", 2);
            this.cards.Add("3", 3);
            this.cards.Add("4", 4);
            this.cards.Add("5", 5);
            this.cards.Add("6", 6);
            this.cards.Add("7", 7);
            this.cards.Add("8", 8);
            this.cards.Add("9", 9);
            this.cards.Add("10", 10);
            this.cards.Add("J", 10);
            this.cards.Add("D", 10);
            this.cards.Add("K", 10);
            this.cards.Add("T", 10);
        }
        
        void welcomeMessage()
        {
            Console.WriteLine("Hi Gamer! Welcome to Twenty-One game");
        }

        uint getCardsCount()
        {
            uint countCard = 0;
            while (countCard <= 0)
            {
                try
                {
                    countCard = uint.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid card`s count. Please try again.");
                }
            }
            return countCard;
        }

        bool isValidCard(string cardCode)
        {
            return this.cards.ContainsKey(cardCode);
        }
        
        uint getCardWeight(string cardCode)
        {
            return this.cards[cardCode];
        }

        string requestCardsCode()
        {
            string cardCode = null;
            while (cardCode == null)
            {
                Console.WriteLine("Input card: ");
                string inputLine = Console.ReadLine();
                inputLine = inputLine.ToUpper();
                if (isValidCard(inputLine))
                {
                    return inputLine;
                }
                else
                {
                    Console.WriteLine("Invalid card");
                }
            }
            return null;
        }
        
        uint requestSummCards()
        {
            uint cardsCount = getCardsCount();
            uint cardsWeightsSumm = 0;
            for (int i = 0; i < cardsCount; i++)
            {
                string cardCode = requestCardsCode();
                if (cardCode != null)
                {
                    uint codeWeight = getCardWeight(cardCode);
                    cardsWeightsSumm += codeWeight;
                }
            }

            return cardsWeightsSumm;
        }

        public void start()
        {
            this.initCardsList();
            this.welcomeMessage();
            Console.WriteLine(this.requestSummCards());
        }
    }
    
    
    
}