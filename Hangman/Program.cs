using System;

namespace Hangman
{

    //Objectives:
    //Making an array to store list of words for user to guess - COMPLETE
    //Making an array of characters and split the words into chars

    class Program
    {
        static string ListOfWords()
        {
            var generator = new Random();
            string[] arr = { "awesome", "lovely" };
            int randomNumber = generator.Next(0, arr.Length - 1);
            return arr[randomNumber];
        }
        static void Main(string[] args)
        {
            Console.WriteLine(ListOfWords());
        }
    }
}
