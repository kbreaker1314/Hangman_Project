using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class TheBoard
    {
        public static bool Board(string input, int countLose = 0)
        {
            int keepTrack = 0;
            //check if the user input is matching any letter in the word, if yes -- replace the letter with user input
            for (int i = 0; i < Program.replaceWord.Count; i++)
            {
                if (input == Program.replaceWord[i])
                {
                    Program.holder[i] = input;
                }
                if (input != Program.replaceWord[i])
                {
                    keepTrack++;
                    if (keepTrack == Program.replaceWord.Count)
                    {
                        BoardReseting.BoardReset(Program.holder, countLose);
                        return true;
                    }
                }
            }
            //reprint the board after each guesses to update user. console.clear() ?
            BoardReseting.BoardReset(Program.holder, countLose);
            return false;
        }
    }
}
