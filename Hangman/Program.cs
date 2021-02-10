﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{

    //Objectives:
    //Making an array to store list of words for user to guess                      [x]
    //Making an array of characters and split the words into chars                  [x]
    //Taking user's input and replace them with the correct word                    [x]
    //Cleaning up left over codes and unnecessary comments                          [x]
    //Making boardPrint function to clear console and reprint game board            [ ]

    //POSSIBLE function:
    //Having user add a word to guess                                               [ ]
    //HINTS?                                                                        [ ]
    //optimize the method to char type instead of string                            [ ]
    class Program
    {
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
            //check if the user input is matching any letter in the word, if yes -- replace the letter with user input
            for (int i = 0; i < replaceWord.Count; i++)
            {
                if(input == replaceWord[i])
                {
                    holder[i] = input;
                }
            }
            //reprint the board after each guesses to update user. console.clear() ?
            foreach ( var n in holder)
            {
                Console.Write(n + space);
            }
        }

        static void Main(string[] args)
        {
            bool gameRun = true;

            // INTRO TO THE GAME
            Console.WriteLine("Welcome to Hangman\n\n\n");
            Console.WriteLine("All you have to do is guess the word -- GOODLUCK\n\n");

            // Making a copy of the word and pass it to Board method
            string copyRealWord = WordGenerate();

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

                //get the first input
                char input = Console.ReadLine()[0];

                //calling board method 
                Board(input.ToString());

                
            
            
                //stopping the game
                //gameRun = false;
            } while (gameRun);
            
            

        }
    }
}
