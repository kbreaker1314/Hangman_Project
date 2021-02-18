using System;

namespace Hangman
{
    class WordGenerating
    {
        public static string WordGenerate(bool user = false, string addWord = "")
        {
            bool userInput = user;
            int theUserWord = 0;
            //Going through the list of words and randomize one word for the user to guess
            var generator = new Random();
            //user input to set to only run through if loop for user input 
            if (addWord != "" && userInput == true)
            {
                Program.UserOfWords.Add(addWord);
                theUserWord = generator.Next(0, Program.UserOfWords.Count);
            }
            //get the word from user input generated list
            if (addWord == "" && userInput == true) return Program.UserOfWords[theUserWord];
            int theActualWord = generator.Next(0, Program.ListOfWords.Count);
            return Program.ListOfWords[theActualWord];
        }
    }
}
