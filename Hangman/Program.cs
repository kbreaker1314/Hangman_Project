using System;
using System.Collections.Generic;
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
        static List<string> wordGuessed = new List<string>();
        static char[] wordCharacter;
        //give space between letters
        static string space = " ";
        static string WordGenerate()
        {
            //Going through the list of words and randomize one word for the user to guess
            var generator = new Random();
            string[] arr = { "awesome", "lovely" };
            int theActualWord = generator.Next(0, arr.Length - 1);
            return arr[theActualWord];
        }
        
        //PLEASE CHANGE THE CHAR INPUT TO STRING AND TEST AGAIN BECAUSE arr[j] IS NOT == THE WORD[i]
        static void Board(string theWord, string input)
        {
            //PROBLEM IS THAT IF THE USER INPUT A CHARACTER THAT ALREADY GUESSED, THE CONSOLE WILL PRINT OUT BOTH CHARS 
            //POSSIBLE SOLUTION: MAKE THAT IF THERE IS A REPEATED INPUT, IGNORE THE INPUT / ASK USER TO PUT ANOTHER
            wordGuessed.Add(input);
            for(int i = 0; i < theWord.Length; i++)
            {
                int counter = 0;
                string theWordHolder = theWord[i].ToString();
                foreach (var n in wordGuessed)
                {
                    if(n.Equals(theWordHolder))
                    {
                        Console.Write(theWord[i] + space);
                    }
                    else if (counter != 1)
                    {
                        Console.Write('_' + space);
                        counter++;
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //char[] saveInput = { 'a', 'b' };
            bool gameRun = true;
            //int numberOfCharacters;


            // INTRO TO THE GAME
            Console.WriteLine("Welcome to Hangman\n\n\n");
            Console.WriteLine("All you have to do is guess the word -- GOODLUCK\n\n");

            // Making a copy of the word and pass it to Board method
            string copyRealWord = WordGenerate();

            //converting the word to char type
            wordCharacter = copyRealWord.ToCharArray();

            //Board(wordCharacter, saveInput);
            //numberOfCharacters = copyRealWord.Length;
            //char[] arr = new char[numberOfCharacters];

            Console.WriteLine(wordCharacter);

            //printing out the spaces and placeholder for each letter
            for (int i = 0; i < copyRealWord.Length; i++)
            {
                Console.Write("_" + space);
            }

            do
            {
                //LEARNT TODAY CONSOLE.READLINE()[0];
                // ^ the input will only store the position of this placement ex: "aspq" -> store "a"
                Console.WriteLine("Guess a letter: ");
                char input = Console.ReadLine()[0];
                //saveInput.Append(input);

                Board(copyRealWord, input.ToString());

                //Console.WriteLine(input);

                //for ( int i = 0; i < copyRealWord.Length; i++)
                //{
                //    if (input == wordCharacter[i])
                //    {
                //        wordCharacter[i] = input;
                //        Console.Write(input + space);
                //    }
                //    else
                //    {
                //        Console.Write("_" + space);
                //    }
                //}
                
                
            
            
            
                //gameRun = false;
            } while (gameRun);
            
            

        }
    }
}
