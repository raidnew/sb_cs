using System;
using System.Collections.Generic;

namespace Task3_10
{
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