using System;

namespace Test3
{
    internal class Program
    {
        static string crbr = "\n";
        
        private string fullName;
        private int age;
        private string email;
        private double scoreProgramming;
        private double scoreMathemetics;
        private double scorePhisics;

        public void completeTestData()
        {
            this.age = 208;
            this.fullName = "Ada Lovelace";
            this.email = "unknown@unknown.unknown";
            this.scoreMathemetics = Double.PositiveInfinity;
            this.scorePhisics = Double.PositiveInfinity;
            this.scoreProgramming = Double.PositiveInfinity;
        }

        private double getScoreAverage()
        {
            return (this.scoreProgramming + this.scorePhisics + this.scoreMathemetics) / 3;
        }
        
        public static void Main(string[] args)
        {
            Program testPerson = new Program();
            testPerson.completeTestData();
            Console.Write(testPerson.toString());
            Console.ReadKey();
            Console.Write($"  Average score: {testPerson.getScoreAverage()}");
            Console.ReadKey();
        }

        public string toString()
        {
            return $"Fullname: {this.fullName}{crbr}" +
                   $"Age: {this.age}{crbr}" +
                   $"Email: {this.email}{crbr}" +
                   $"Score:{crbr}" +
                   $"  Programming: {this.scoreProgramming}{crbr}" +
                   $"  Mathematics: {this.scoreMathemetics}{crbr}" +
                   $"  Phisics: {this.scorePhisics}{crbr}";
        }
    }
}