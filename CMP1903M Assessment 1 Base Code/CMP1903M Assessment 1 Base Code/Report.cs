using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Report
    {
        //Handles the reporting of the analysis
        //Maybe have different methods for different formats of output?
        //eg.   public void outputConsole(List<int>)

        //Method: outputConsole
        //Arguments: list of integers
        //Returns: none
        //Prints the analysis to the console

        static public void outputConsole(List<int> analysis)
        {
            Console.WriteLine("Number of sentences: " + analysis[0]);
            Console.WriteLine("Number of vowels: " + analysis[1]);
            Console.WriteLine("Number of consonants: " + analysis[2]);
            Console.WriteLine("Number of upper case letters: " + analysis[3]);
            Console.WriteLine("Number of lower case letters: " + analysis[4]);
        }

        //Method: outputConsoleAdvanced - ADDITIONAL METHOD
        //Arguments: dictionary: char key, int value (letter frequencies)
        //Returns: none
        //Prints the advanced analysis to the console

        static public void outputConsoleAdvanced(Dictionary<char, int> analysis)
        {
            foreach (var letter in analysis)
            {
                Console.WriteLine("Letter: " + letter.Key + "  " + "Frequency = " + letter.Value);
            }
        }

        //Method: outputFile - ADDITIONAL METHOD
        //Arguments: list of strings (long words)
        //Returns: none
        //Creates a file and writes the list of long words (7+letters) to this file

        static public void outputFile(List<string> longWords)
        {
            //Asks the user for a file path - loops until valid path obtained
            while (true)
            {
                Console.WriteLine("Please enter a valid file path (including the file name) to store the long word file");
                string path = @"" + Console.ReadLine();

                //Try-catch blocks covers for all errors found from testing various inputs
                try
                {
                    //Uses a TextWriter to allow the file to be written to a specific location
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        //Each word is written on a new line in the document
                        foreach (string word in longWords)
                        {
                            sw.WriteLine(word);
                        }
                    }

                    //If an expection is not raised from trying to write to the new file, the loop is broken
                    break;
                }

                //Exceptions
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Invalid directory. Please check the path is correct");
                }

                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access to folder denied (Have you missed out the file name?)");
                }

            }


        }

    }
}