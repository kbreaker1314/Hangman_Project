using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class GetHint
    {
        //first try !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //returning the letter but also returning guessed letters
        public string TheHint(List<string> wordList, List<string> blankList)
        {
            var randomizer = new Random();
            List<string> theHintList = new List<string>();
            for ( int i = 0; i < wordList.Count; i++)
            {
                //comparing full-word list and currently guessing list. add the letter to the HintList if the letter is not guessed
                if ( blankList[i] != wordList[i])
                {
                    theHintList.Add(wordList[i]);
                }
            }
            //generating from the list of the words th at is not guessed
            int result = randomizer.Next(0, theHintList.Count);
            return theHintList[result];


            //This will return guessed letters
            //int result = randomizer.Next(0, theWord.Length);
            //return theWord[result].ToString();
            //return "";
        }
    }
}
