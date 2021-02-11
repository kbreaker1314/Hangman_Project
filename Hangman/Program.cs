﻿using System;
using System.Collections.Generic;


namespace Hangman
{

    //Objectives:
    //Making an array to store list of words for user to guess                      [x] 2/06/2021
    //Making an array of characters and split the words into chars                  [x] 2/06/2021
    //Taking user's input and replace them with the correct word                    [x] 2/08/2021
    //Cleaning up left over codes and unnecessary comments                          [x] 2/09/2021
    //Making boardPrint function to clear console and reprint game board            [x] 2/10/2021
    //Method to win the game                                                        [x] 2/11/2021
    //Winning Screen                                                                [ ] 2/12/2021
    //Guessing wrong conditions                                                     [ ] 2/13/2021

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
            int theActualWord = generator.Next(0, arr.Length);
            return arr[theActualWord];
        }

        //clear the board and reprint updated board + hangman image
        static void BoardReset(List<string> holderList)
        {
            Console.Clear();
            Console.WriteLine("      _______    ");
            Console.WriteLine("     ||      |");
            Console.WriteLine("     ||      |");
            Console.WriteLine("     ||      |");
            Console.WriteLine("     ||      |");
            Console.WriteLine("     ||      |");
            Console.WriteLine(" =========   |");
            Console.WriteLine("             |");
            Console.Write("      ");
            foreach (var n in holderList)
            {
                Console.Write(n + space);
            }

        }
        static void Board(string input)
        {
            //check if the user input is matching any letter in the word, if yes -- replace the letter with user input
            for (int i = 0; i < replaceWord.Count; i++)
            {
                if (input == replaceWord[i])
                {
                    holder[i] = input;
                }
            }
            //reprint the board after each guesses to update user. console.clear() ?
            BoardReset(holder);
        }

        static void Main(string[] args)
        {
            bool gameRun = true;

            // INTRO TO THE GAME
            Console.WriteLine("Welcome to Hangman\n\n\n");
            Console.WriteLine("All you have to do is guess the word -- GOODLUCK\n\n");
            Console.WriteLine("enter Y to start: ");
            string startGame = Console.ReadLine();
            if (startGame == "y")
            {
                // Making a copy of the word and pass it to Board method
                string copyRealWord = WordGenerate();

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

                Board(null);

                do
                {
                    //LEARNT TODAY CONSOLE.READLINE()[0];
                    // ^ the input will only store the position of this placement ex: "aspq" -> store "a"

                    //get the first input
                    Console.Write("\n\nGuess a letter: ");
                    char input = Console.ReadLine()[0];

                    //calling board method 
                    Board(input.ToString());


                    // after CheckWin, if there are still blank -- Checkwin = false, therefore gameRun == true ( satisfy second statement )
                    gameRun = WinCondition.CheckWin(holder) ? false : true;
                } while (gameRun);

            }

        }
    }
}