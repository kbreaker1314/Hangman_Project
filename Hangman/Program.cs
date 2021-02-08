using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{

    //Objectives:
    //Making an array to store list of words for user to guess - COMPLETE
    //Making an array of characters and split the words into chars - COMPLETE
    //Taking user's input and replace them with the correct word - COMPLETE
    //Cleaning up left over codes and unnecessary comments 

    //POSSIBLE function:
    //Having user add a word to guess
    //HINTS?
    class Program
    {
        //static List<string> wordGuessed = new List<string>();
        //replaceWord is holding the actual word
        static List<string> replaceWord = new List<string>();
        //holder is holding the '_' and replace as neccessary 
        static List<string> holder = new List<string>();
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
        
        static void Board(string input)
        {
            //FINALLLYYY FIGURED OUTT THE BOARD METHOD AND IS ABLE TO PRINT USING USER'S INPUT 
            //for loop check if the input matches up with any letter of the given word, if yes, replace holder with the letter
            for (int i = 0; i < replaceWord.Count; i++)
            {
                if(input == replaceWord[i])
                {
                    holder[i] = input;
                }
            }
            //reprint the board after each guesses to update user.
            foreach ( var n in holder)
            {
                Console.Write(n + space);
            }


            


            ///* PROBLEM --- cannot get to not print extra '_' when guessing correctly
            //int letterCounter = 0;
            //foreach ( string n in wordGuessed)
            //{
            //    if (input.Equals(n))
            //    {
            //        letterCounter++;
            //    }
            //}
            //if(letterCounter < 1)
            //{
            //    wordGuessed.Add(input);
            //}
            //
            //for(int i = 0; i < theWord.Length; i++)
            //{
            //    int counter = 0;
            //    string theWordHolder = theWord[i].ToString();
            //    for(int j = 0; j < wordGuessed.Count; j++)
            //    {
            //        int counter2 = 0;
            //        //theWordHolder is still 'a' when wordGuessed[j] --- so it will print out extra _ because counter is less than 1 
            //        if(wordGuessed[j].Equals(theWordHolder))
            //        {
            //            Console.Write(theWord[i] + space);
            //            counter2++;
            //        }
            //        else 
            //        {
            //            Console.Write("_" + space);
            //            counter++;
            //
            //        }
            //    }
            //}
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

            //Board(wordCharacter, saveInput);
            //numberOfCharacters = copyRealWord.Length;
            //char[] arr = new char[numberOfCharacters];


            //printing out the spaces and placeholder for each letter
            for (int i = 0; i < copyRealWord.Length; i++)
            {
                Console.Write("_" + space);
            }

            //converting words from string to char-array and then back to string.
            char[] copyWord = copyRealWord.ToCharArray();
            for (int i = 0; i < copyWord.Length; i++)
            {
                replaceWord.Add(copyWord[i].ToString());
            }
            //adding initial blank spaces for user's first guess
            foreach (var n in replaceWord)
            {
                holder.Add("_");
            }

            do
            {
                //LEARNT TODAY CONSOLE.READLINE()[0];
                // ^ the input will only store the position of this placement ex: "aspq" -> store "a"
                Console.WriteLine("Guess a letter: ");
                char input = Console.ReadLine()[0];
                //saveInput.Append(input);

                Board(input.ToString());

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
