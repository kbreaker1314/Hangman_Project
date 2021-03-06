using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class TheBoard
    {
        //return true if letter is wrong
        public static bool Board(string input, int countLose = 0, int hintCount = 3)
        {
            bool isInputNotFound = true;
            //check if the user input is matching any letter in the word, if yes -- replace the letter with user input
            for (int i = 0; i < Program.replaceWord.Count; i++)
            {
                if (input == Program.replaceWord[i])
                {
                    Program.holder[i] = input;
                    isInputNotFound = false;
                }
            }
            //reprint the board after each guesses to update user. console.clear() ?
            BoardReseting.BoardReset(Program.holder, countLose, hintCount);
            return isInputNotFound;
        }
    }
}
