//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main()
        {
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();

            //Create 'Input' object
            Input input = new Input();

            //Loops until user's choice of input accepted by property ("manual" or "file")
            while (input.Choice == null)
            {
                Console.WriteLine("Please enter either 'manual' (enter your own text on the keyboard) or 'file'(reads text from the file)");
                //Input converted to lower case to stop check being case sensitive
                input.Choice = Console.ReadLine();
            }

            //Get either manually entered text, or text from a file
            string text = "";
            //Gets manually entered text
            if (input.Choice == "manual")
            {

                text = input.manualTextInput();

            }
            //Gets text from file
            else if (input.Choice == "file")
            {
                //Loops until a valid file name is obtained
                while (input.Path == null)
                {
                    Console.WriteLine("Please enter a valid file path");
                    input.Path = @"" + Console.ReadLine();

                }
                text = input.fileTextInput();
            }

            //Create an 'Analyse' object
            Analyse analyse = new Analyse();

            //Pass the text input to the 'analyseText' method
            //Receive a list of integers back
            parameters = analyse.analyseText(text);


            //Report the results of the analysis
            Report.outputConsole(parameters);

            //Break in program to allow user to read basic analysis
            Console.WriteLine("Press any key to continue to advanced analysis");
            Console.ReadLine();

            //TO ADD: Get the frequency of individual letters?
            //Create an 'advancedAnalyse' object
            advancedAnalyse advancedanalyse = new advancedAnalyse();

            //Get a dictionary containing the letter frequency and a list containg long words
            Dictionary<char, int> characterList = advancedanalyse.letterFrequency(text);

            List<string> longWords = advancedanalyse.getLongWords(text);

            //Report the results of the advanced analysis
            Report.outputConsoleAdvanced(characterList);
            Report.outputFile(longWords);


        }
    }
}

