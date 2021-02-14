using System;
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
    //Winning Screen                                                                [x] 2/12/2021
    //Guessing wrong conditions                                                     [x] 2/13/2021

    //POSSIBLE function:
    //Having user add a word to guess                                               [x] 2/14/2021
    //having option to choose from different lists                                  [ ]
    //HINTS?                                                                        [ ]
    //optimize the method to char type instead of string                            [ ]
    //add already guessed letters                                                   [ ]
    //add alphabet                                                                  [ ]

    //Problems:
    //When user input nothing -- out of range                                       [ ]
    class Program
    {
        static List<string> arr = new List<string>() { "awesome" };
        //replaceWord is holding the actual word
        static List<string> replaceWord = new List<string>();
        //holder is holding the '_' and replace as neccessary 
        static List<string> holder = new List<string>();
        //give space between letters
        static string space = " ";
        static string WordGenerate(string addWord = "")
        {
            //Going through the list of words and randomize one word for the user to guess
            var generator = new Random();
            if (addWord != "") arr.Add(addWord);

            int theActualWord = generator.Next(0, arr.Count);
            return arr[theActualWord];
        }

        //clear the board and reprint updated board + hangman image
        static void BoardReset(List<string> holderList, int countLose)
        {
            //if-else statement to check for how many turns user is wrong and return hang man image according to the number of wrong guesses
            Console.Clear();
            Console.WriteLine("      ______________  ");
            Console.WriteLine("     ||             |");
            Console.WriteLine("     ||             |");
            Console.WriteLine("     ||             |");
            if (countLose >= 1)
            {
                Console.Write("     ||         ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("    O    ");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("     ||      ");
            }
            
            if (countLose >= 2)
            {
                Console.Write("     ||        ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  --(O)-- ");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("     ||      ");
            }
            if (countLose >= 3)
            {
                Console.Write("     ||        ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"    / \   YOU LOSE!! Nice try tho");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("     ||      ");
            }
            Console.WriteLine("     ||      ");
            Console.WriteLine("     ||      ");
            Console.WriteLine("     ||      ");
            Console.WriteLine(" =========   ");
            Console.WriteLine("             ");
            Console.Write("      ");
            foreach (var n in holderList)
            {
                Console.Write(n + space);
            }
            Console.WriteLine("----The number of wrong guesses: " + countLose);
        }
        static bool Board(string input, int countLose = 0)
        {
            int keepTrack = 0;
            //check if the user input is matching any letter in the word, if yes -- replace the letter with user input
            for (int i = 0; i < replaceWord.Count; i++)
            {
                if (input == replaceWord[i])
                {
                    holder[i] = input;
                }
                if (input != replaceWord[i])
                {
                    keepTrack++;
                    if (keepTrack == replaceWord.Count)
                    {
                        BoardReset(holder, countLose);
                        return true;
                    }
                }
            }
            //reprint the board after each guesses to update user. console.clear() ?
            BoardReset(holder, countLose);
            return false;
        }

        static void Main(string[] args)
        {
            bool gameRun = true;
            int countLose= 0;

            // INTRO TO THE GAME
            Console.WriteLine("Welcome to Hangman\n\n\n");
            Console.WriteLine("All you have to do is guess the word -- GOODLUCK\n\n");
            Console.WriteLine("enter Y to start: ");
            string startGame = Console.ReadLine();
            if (startGame == "y")
            {
                // Making a copy of the word and pass it to Board method
                Console.WriteLine("Do you want to add a word of your own? Y/N");
                char answer = Console.ReadLine()[0];
                while (answer == 'y')
                {
                    Console.WriteLine("Word will be generated randomly");
                    Console.WriteLine("--Enter NOTHING to finish--");
                    Console.Write("Enter the word you want to add: ");
                    string addWord = Console.ReadLine();
                    WordGenerate(addWord);
                    if (addWord == string.Empty) answer = 'n';
                }

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
                    bool keepTheCount = Board(input.ToString());
                    if (keepTheCount == true) countLose++;

                    //calling board method and assign it to keepthecount for wrong guesses
                    //lesson  learn: have to print board afterward to be able to calculate the new countLose.
                    Board(input.ToString(), countLose);


                    // after CheckWin, if there are still blank -- Checkwin = false, therefore gameRun == true ( satisfy second statement )
                    gameRun = WinCondition.CheckWin(holder) ? false : true;
                    if (gameRun == false)
                    {
                        Console.WriteLine();
                        //changing text color to Red
                        Console.ForegroundColor = ConsoleColor.Red;
                        string winGame = "CONGRATULATIONS, YOU WON!";
                        //setting text center
                        Console.SetCursorPosition((Console.WindowWidth - winGame.Length) / 2 - 4, Console.CursorTop);
                        Console.WriteLine(winGame);
                        //changing back to default (white)
                        Console.ResetColor();
                    }
                    if (countLose >= 3) gameRun = false;
                } while (gameRun);
                Console.WriteLine("enter any key to exit....");
                Console.ReadLine();
            }

        }
    }
}