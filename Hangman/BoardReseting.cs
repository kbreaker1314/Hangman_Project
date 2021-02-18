using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class BoardReseting
    {
        //clear the board and reprint updated board + hangman image
        public static void BoardReset(List<string> holderList, int countLose)
        {
            string space = " ";
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
    }
}
