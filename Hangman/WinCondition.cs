using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class WinCondition
    {
        static public bool CheckWin(List<string> holder)
        {

            // if there are less than 1 blank space, user win the game. statement return true, gamerun = false.
            int win = 0;
            foreach ( var n in holder)
            {
                if (n == "_")
                {
                    win++;
                }
            }
            if (win < 1) return true;
            return false;
        }
    }
}
