using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    internal class IngredientClass
    {
        public string IngredientName { get; set; } = string.Empty;

        public double IngredientQuantity { get; set; } = 0;

        public string MeasurementUnit { get; set; } = string.Empty;

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default constructor
        /// </summary>
        public IngredientClass()
        {

        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to assign values to variables
        /// </summary>
        public void IngredientInput()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            this.IngredientName = this.GetValidString();

            this.IngredientQuantity = this.GetIntegerInputFromUser("\r\nPlease enter the Quantity of the Ingredient:");

            this.MeasurementUnit = this.GetStringInputFromUser("\r\nPlease enter the Measurement Unit:");

            //this.MeasurementUnit = this.MeasurementUnitInput();
        }

        public string GetValidString()
        {
            string input;
            bool isValid = false;

            do
            {
                Console.WriteLine("Please enter the Name of the Ingredient: ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    this.ErrorPrint("\r\nInvalid input. Please enter a non-null string.");
                }
                else if (!input.All(c => char.IsLetter(c) || c == ' '))
                {
                    this.ErrorPrint("\r\nInvalid input. Please enter a string containing only letters and spaces.");
                }
                else
                {
                    isValid = true;
                }
            } while (!isValid);

            return input;
        }
        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input Ingredient Name with error checking
        /// </summary>
        /// <returns></returns>
        public string IngredientNameInput()
        {
            Console.WriteLine("Please enter the Name of the Ingredient: ");
            string input = Console.ReadLine();
            string result = "";

            try
            {
                foreach (char c in input)
                {
                    if (char.IsLetter(c))
                    {
                        result += c;
                    }
                    else
                    {
                        this.ErrorPrint("\r\nInput can only contain letters.");
                        this.IngredientNameInput();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input Ingredient Quantity with error checking
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public double IngredientQuantityInput(string input)
        {
            double ingNum = 0;
            try
            {
                bool isOnlyDigits = !string.IsNullOrEmpty(input) && input.All(char.IsDigit);

                if (isOnlyDigits)
                {
                    ingNum = double.Parse(input);
                }
                else
                {
                    this.ErrorPrint("\r\nPlease only enter digits");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ingNum;
        }

        public double GetIntegerInputFromUser(string inputString)
        {
            double number;
            bool isValidInput = false;

            do
            {
                Console.WriteLine(inputString);
                string input = Console.ReadLine();

                if (!double.TryParse(input, out number) || input.Contains("-") || !input.All(char.IsDigit) || input.Contains("0"))
                {
                    this.ErrorPrint("\r\nInvalid input. Please enter a number.");
                }
                else
                {
                    isValidInput = true;
                }
            } while (!isValidInput);

            return number;
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input Measurement Unit with error checking
        /// </summary>
        /// <returns></returns>
        public string MeasurementUnitInput()
        {
            Console.WriteLine("\r\nPlease enter the Measurement Unit of the Ingredient: ");
            string input = Console.ReadLine();
            string result = "";

            try
            {
                foreach (char c in input)
                {
                    if (char.IsLetter(c))
                    {
                        result += c;
                    }
                    else
                    {
                        this.ErrorPrint("\r\nInput can only contain letters.");
                        this.MeasurementUnitInput();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Returns value if input is not null and only consists of letters
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string GetStringInputFromUser(string inputString)
        {
            string input;
            bool isValidInput = false;

            do
            {
                Console.WriteLine(inputString);
                input = Console.ReadLine();

                if (string.IsNullOrEmpty(input) || !input.All(char.IsLetter))
                {
                    this.ErrorPrint("Invalid input. Please enter only letters.");
                }
                else
                {
                    isValidInput = true;
                }
            } while (!isValidInput);

            return input;
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Displays message in correct format for errors
        /// </summary>
        /// <param name="input"></param>
        public void ErrorPrint(string input)
        {
            // Set the console foreground color to red
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(input);

            // Reset the console foreground color
            Console.ResetColor();
        }

    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//