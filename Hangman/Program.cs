using System;
using System.Linq;

namespace Hangman
{

    //Objectives:
    //Making an array to store list of words for user to guess - COMPLETE
    //Making an array of characters and split the words into chars

    //POSSIBLE function:
    //Having user add a word to guess
    //HINTS?
    class Program
    {
        static string theRealWord()
        {
            //Going through the list of words and randomize one word for the user to guess
            var generator = new Random();
            string[] arr = { "awesome", "lovely" };
            int theActualWord = generator.Next(0, arr.Length - 1);
            return arr[theActualWord];
        }
        static void Board(string passingWord)
        {
            //passing the word from Main and convert into char type and print the spaces required.
            char[] character = passingWord.ToCharArray();
            //unnesscary for now
            char[] fakeWord = character;
            Console.WriteLine(character);
            for (int i = 0; i < fakeWord.Length; i++)
            {
                Console.Write("_ ");
            }
        }
        
        static void Main(string[] args)
        {
            //bool gameRun = true;
            /// INTRO TO THE GAME
            Console.WriteLine("Welcome to Hangman\n\n\n");
            Console.WriteLine("All you have to do is guess the world -- GOODLUCK\n\n");
            /// Making a copy of the word and pass it to Board method
            string copyRealWord = theRealWord();
            Board(copyRealWord);
            //do
            //{
            //    Console.WriteLine("Guess a letter: ");
            //    char input = Console.ReadLine()[0];
            //    Console.WriteLine(input);
            //    
            //    
            //
            //
            //
            //    gameRun = false;
            //} while (gameRun);
            //
            //

        }
    }
}
