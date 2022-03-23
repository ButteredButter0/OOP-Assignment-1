using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(string input)
        {
            //List of integers to hold the first five measurements:
            //1. Number of sentences
            //2. Number of vowels
            //3. Number of consonants
            //4. Number of upper case letters
            //5. Number of lower case letters
            List<int> values = new List<int>();
            //Initialise all the values in the list to '0'
            for (int i = 0; i < 5; i++)
            {
                values.Add(0);
            }


            foreach (char character in input)
            {


                //Calulcates sentences
                //Checks against ascii values of '.', '?' and '!' respectively, as these indicate the end of a sentence
                if (character == 46 | character == 63 | character == 33)
                {
                    values[0]++;
                }
                //All other checks in seperate 'else' block as if character is a punctuation mark, no further checks need to be made
                else
                {
                    //Checks against ascii values of upper and lower case vowels
                    if (character == 65 | character == 69 | character == 73 | character == 79 | character == 85 | character == 97 | character == 101 | character == 105 | character == 111 | character == 117)
                    {
                        values[1]++;
                    }

                    //Checks against all other ascii values of letters, checking for consonants by deduction
                    else if ((character >= 65 && character <= 90) | (character >= 97 && character <= 122))
                    {
                        values[2]++;
                    }

                    //Checks against ascii values of upper case letters
                    if (character >= 97 && character <= 122)
                    {
                        values[3]++;
                    }

                    //Checks against ascii values of lower case letters
                    if ((character >= 65 && character <= 90))
                    {
                        values[4]++;
                    }
                }

            }


            return values;
        }

    }
}