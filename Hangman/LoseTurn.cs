using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class LoseTurn
    {
        static int CheckLose(List<string> holder, string input)
        {
            for (int i = 0; i < holder.Count; i++)
            {
                if (input != holder[i])
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
