using System;
using System.Linq;

namespace Task5_5
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            new Task5dot5();
        }
    }

    class Task5dot5
    {
        public Task5dot5()
        {
            string textWithWordsDelmitSpaces = GetTextForSplit();
            string[] wordsArray = SplitText(textWithWordsDelmitSpaces);
            OutputArrayInLines(wordsArray);
            Console.WriteLine(ReverseWords(textWithWordsDelmitSpaces));
        }

        private string GetTextForSplit()
        {
            string inputString = Console.ReadLine();
            if(inputString == "") return "Word1 Word2 Word3 Word4 Word5 Word6 Word7 Word8";
            return inputString;
        }

        private string ReverseWords(string text)
        {
            string[] wordsArray = SplitText(text);
            Array.Reverse(wordsArray);
            return String.Join(" ", wordsArray);
        }

        private string[] SplitText(string text, char delmitter = ' ')
        {
            return text.Split(delmitter);
        }

        private void OutputArrayInLines(string[] wordsArray)
        {
            foreach (string word in wordsArray)
            {
                Console.WriteLine(word);
            }
        }
    }
}