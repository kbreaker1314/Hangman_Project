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
    //HINTS? --- ONE TRYYY                                                          [x] 2/27/2021
    //add limited hints that the user can get per round                             [x] 3/06/2021
    //making the program only process alphabet letter  (line 117 program.cs)        [ ] 3/07/2021
    //add comments and identifying method clearly                                   [ ]

    //POSSIBLE function:
    //Having user add a word to guess                                               [x] 2/14/2021
    //having option to choose from different lists                                  [x] 2/15/2021
    //add already guessed letters                                                   [x] 2/16/2021
    //add the answer if you lose                                                    [x] 2/17/2021
    //organizing methods into classes and clean up codes                            [x] 2/18/2021
    //show user what they put on their list                                         [x] 2/19/2021 

    //Problems:
    //Fix case sensitive problem                                                    [x] 2/20/2021
    //when user input nothing -- for input                                          [x] 2/26/2021
    //guessing same wrong letter                                                    [x] 2/28/2021
    class Program
    {

        //list of the words for default list and user's list
        public static List<string> ListOfWords = new List<string>() { "awesome", "lovely", "determined" };
        public static List<string> UserOfWords = new List<string>() { };

        //replaceWord is holding the actual word
        public static List<string> replaceWord = new List<string>();
        //holder is holding the '_' and replace as neccessary 
        public static List<string> holder = new List<string>();
        static void Main(string[] args)
        {
            GetHint getHint = new GetHint();
            List<char> guessedLetter = new List<char>();
            bool gameRun = true;
            int countLose = 0, countRepeatedLetter = 0, hintCount = 3;
            string copyRealWord = "", stringEmpty = "";
            bool userInput = false;
            char input = ' ';

            // INTRO TO THE GAME
            Console.WriteLine("Welcome to Hangman\n\n\n");
            Console.WriteLine("All you have to do is guess the word -- GOODLUCK\n\n");
            Console.WriteLine("enter Y to start: ");
            string startGame = Console.ReadLine();
            startGame = startGame.ToLower();
            if (startGame == "y")
            {
                // Making a copy of the word and pass it to Board method
                Console.WriteLine("Do you want to add a word of your own? Y/N");
                char answer = Console.ReadLine()[0];
                answer = char.ToLower(answer);
                Console.WriteLine("Word will be generated randomly");
                while (answer == 'y')
                {
                    //setting userinput = true so the default list would not override user list
                    userInput = true;
                    Console.SetCursorPosition((Console.WindowWidth - 20) / 2 - 4, Console.CursorTop);
                    Console.WriteLine("--Enter NOTHING to finish--");
                    Console.Write("Enter the word you want to add: ");
                    //adding the word in lower case
                    string addWord = Console.ReadLine().ToLower();
                    WordGenerating.WordGenerate(true, addWord);

                    //clear the board and print out the list for user to see what they've input
                    Console.Clear();
                    Console.Write("\n\nThe current list is: ");
                    foreach (var n in UserOfWords)
                    {
                        Console.Write(n + " ");
                    }
                    Console.WriteLine();
                    if (addWord == string.Empty) answer = 'n';
                    copyRealWord = WordGenerating.WordGenerate(true, string.Empty);
                }
                if (answer != 'y' && userInput == false)
                {
                    copyRealWord = WordGenerating.WordGenerate();
                }

                //possible optimization -- calling WordGenerate twice

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

                //generating the board without inputing a word 
                TheBoard.Board(null);
                do
                {
                    //LEARNT TODAY CONSOLE.READLINE()[0];
                    // ^ the input will only store the position of this placement ex: "aspq" -> store "a"

                    //get the first input
                    do
                    {
                        Console.Write("\n Type -/gethint for a free hint \n\nGuess a letter: ");
                        stringEmpty = Console.ReadLine();
                        if (stringEmpty == "/gethint" && hintCount > 0)
                        {
                            stringEmpty = getHint.TheHint(replaceWord, holder);
                            hintCount--;
                        }
                        //check if string is empty then pass it onto CHAR input if it is not
                        if (!string.IsNullOrEmpty(stringEmpty))
                        {
                            input = stringEmpty[0];
                        }
                        else
                        {
                            Console.WriteLine("\n \nError input. Try again.");
                        }
                    }
                    while (string.IsNullOrEmpty(stringEmpty));
                    //guessLetter variable to print out guessed letter in lower case
                    countRepeatedLetter = 0;
                    foreach ( var n in guessedLetter)
                    {
                        if ( n != input )
                        {
                            countRepeatedLetter += 1;
                        }
                    }
                    if (countRepeatedLetter == guessedLetter.Count)
                    {
                        guessedLetter.Add(char.ToLower(input));
                    }

                    //the case sensitive are convereted to lower case
                    bool keepTheCount = TheBoard.Board(input.ToString().ToLower());
                    if (keepTheCount == true) countLose++;

                    //calling board method and assign it to keepthecount for wrong guesses
                    //lesson  learn: have to print board afterward to be able to calculate the new countLose.
                    TheBoard.Board(input.ToString(), countLose, hintCount);

                    //printing out guessed letter for user
                    Console.Write("\n\n Guessed letters are: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (var n in guessedLetter)
                    {
                        Console.Write(n + " ");
                    }
                    Console.ResetColor();

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
                    if (countLose >= 3)
                    {
                        //if the user guessed wrong 3 times, answer is shown in yellow
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("The answer is: " + copyRealWord);
                        Console.ResetColor();
                        gameRun = false;
                    }
                } while (gameRun);
                Console.WriteLine("enter any key to exit....");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Come back when you are ready!!");
            }
        }
    }
}