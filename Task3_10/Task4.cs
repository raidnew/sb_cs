using System;

namespace Task3_10
{

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
}