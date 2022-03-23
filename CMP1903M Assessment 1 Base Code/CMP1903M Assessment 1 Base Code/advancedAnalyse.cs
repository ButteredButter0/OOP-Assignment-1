using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class advancedAnalyse //ADDITIONAL CLASS CONTAINING ADDITIONAL METHODS
    {

        //Method: letterFrequency
        //Arguments: string (text)
        //Returns: dictionary (keys are letters, values are the counter for that letter)
        //Counts the frequency of all letters (case sensitive)
        public Dictionary<char, int> letterFrequency(string text)
        {
            Dictionary<char, int> letterCounter = new Dictionary<char, int>();

            //Loops through every character in the text
            foreach (char letter in text)
            {
                //Checks the current character is a letter
                if ((letter >= 65 && letter <= 90) | (letter >= 97 && letter <= 122))
                {
                    //Creates a new key for new letters, or adds one to the value of an existing key
                    if (letterCounter.ContainsKey(letter) == false)
                    {
                        letterCounter.Add(letter, 1);
                    }
                    else
                    {
                        letterCounter[letter] += 1;
                    }
                }

            }

            return letterCounter;
        }

        //Method: getLongWords
        //Arguments: string (text)
        //Returns: List of strings (long words)
        //Returns a list of long words (7+ letters) in the text file
        public List<string> getLongWords(string text)
        {
            //Empty list to put 7+ letter words in
            List<string> longWords = new List<string>();
            //Obtains an array of all the words in the text (splits by spaces, new lines and punctuation that gramatically could be next to a word)
            string[] words = text.Split(' ', '\n', ',', '?', '!', '.', '*', ':', ';', '\"', '@', '(', ')', '{', '}', '[', ']', '#', '/');

            //Loops through every word, checking the length - note this assumes that input is gramatically correct
            foreach (string word in words)
            {
                if (word.Length >= 7)
                {

                    longWords.Add(word);
                }
            }

            return longWords;
        }
    }
}