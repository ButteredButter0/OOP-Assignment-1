using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        //Handles the text input for Assessment 1
        private string text = null;


        //Property: Choice - ENCAPSULATION
        //Get: returns value of private choice
        //Set: if value is either "manual" or "file" assigns value to private choice
        //Verifys that user has chosen either to manually enter the text or to read it from a file
        private string choice = null;
        public string Choice
        {
            get { return choice; }
            set
            {

                //Input converted to lower case to stop check being case sensitive
                value = value.ToLower();
                //Handles invalid inputs
                if (value != "manual" && value != "file")
                {
                    Console.WriteLine("Invalid input");
                }

                else
                {
                    choice = value;
                }
            }
        }
        private string path = null;

        //Property: Path - ENCAPSULATION
        //Get: returns value of private path
        //Set: if value is a readable file, value is assigned to private path
        //Verifys that user has entered a valid file path
        public string Path
        {
            get { return path; }
            set
            {
                //Try-catch blocks covers for all errors found from testing various inputs
                try
                {
                    //Large inputs do not automatically throw PathTooLongException, so this code manually does this 
                    if (value.Length >= 256)
                    {
                        throw new PathTooLongException();
                    }
                    File.ReadAllText(value);
                    //If an expection is not raised from trying to read the text from the file path, value can be assigned to path
                    path = value;
                }

                //Exceptions
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine("Invalid directory. Please check the path is correct");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Invalid file name. Please check the file name is correct, and includes .txt");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("Access to folder denied (Have you missed out the file name?)");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Blank entry is invalid. Please enter a valid path.");
                }

                catch (PathTooLongException)
                {
                    Console.WriteLine("Input too large. Please enter a valid path");
                }
            }
        }
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard

        public string manualTextInput()
        {
            //Loops until user enters '*'
            while (true)
            {
                Console.WriteLine("Please enter your sentence(s). Type '*' to end your entry");

                //Adds each sentence to the end of the string "text"
                text = text + Console.ReadLine() + " ";

                if (text.Contains("*") == true)
                {
                    Console.WriteLine("Entry complete. You entered:");
                    Console.WriteLine(text);
                    break;
                }
            }

            return text;
        }


        //Method: fileTextInput
        //Arguments: string (the file path) - ENCAPSULATION MEANS THIS ISN'T NECESSARY
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput()
        {
            string text = File.ReadAllText(path);
            Console.WriteLine("File read");
            return text;
        }

    }
}