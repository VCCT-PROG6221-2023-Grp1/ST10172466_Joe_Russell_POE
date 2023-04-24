using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    internal class StepClass
    {
        public string StepDescription { get; set; } = string.Empty;

        public StepClass()
        { }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to assign values to variables
        /// </summary>
        public void StepInput()
        {

            this.StepDescription = this.StepDescriptionInput();
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input Step Description with error checking
        /// </summary>
        /// <returns></returns>
        public string StepDescriptionInput()
        {
            Console.WriteLine("Please enter the step description: ");
            string input = Console.ReadLine();
            string result = "";

            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    result += input;
                }
                else
                {
                    Console.WriteLine("Input cannot be empty");
                    this.StepDescriptionInput();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//