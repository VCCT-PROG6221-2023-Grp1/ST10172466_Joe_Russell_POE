using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    internal class StepClass
    {
        /// <summary>
        /// String that holds the Step Description
        /// </summary>
        public string StepDescription { get; set; } = string.Empty;

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public StepClass()
        { }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to assign values to variables
        /// </summary>
        public void StepInput()
        {
            this.StepDescription = this.StepDescriptionInputMethod("\r\nPlease enter the step description: ");
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input Step Description, checks that input is not null, with error handling
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string StepDescriptionInputMethod(string inputString)
        {
            string input = "";
            Console.WriteLine(inputString);
            try
            {
                while (string.IsNullOrWhiteSpace(input))
                {
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        // Set the console foreground color to red
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Invalid input. Please enter a non-empty value.");

                        // Reset the console foreground color
                        Console.ResetColor();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return input;
        }

        //-----------------------------------------------------------------------------------------------//
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//