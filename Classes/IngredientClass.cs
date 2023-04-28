using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public string IngredientType { get; set; } = string.Empty;

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
            this.IngredientName = this.IngredientNameInputMethod("\r\nPlease enter the Ingredient Name:");

            //
            int option = GetPositiveIntegerInput("Choose Measurement Unit:" +
                "\r\n       Enter 1 for Millilitres" +
                "\r\n       Enter 2 for Grams");

            //Prevents incorrect switch statement choice
            if (option > 2)
            {
                this.ErrorPrint("\r\nInvalid Input");
                Console.ReadLine();
                return;
            }

            //Switch statement to assign variable   
            switch (option)
            {
                case 1:
                    this.MeasurementUnit = "Millilitres";
                    break;
                case 2:
                    this.MeasurementUnit = "Grams";
                    break;
                default:
                    this.ErrorPrint("Invalid option selected.");
                    Console.ReadLine();
                    break;
            }            

            this.IngredientQuantity = this.IngredientQuantityInputMethod("\r\nPlease enter the Quantity of the Ingredient:");

            //this.MeasurementUnit = this.MeasurementUnitInputMethod("\r\nPlease enter the Measurement Unit:");
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input Ingredient Name, checks that input only contains letters and spaces, with error handling
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string IngredientNameInputMethod(string inputString)
        {
            string input = "";
            Console.WriteLine(inputString);
            try
            {
                while (string.IsNullOrWhiteSpace(input) || !input.Replace(" ", "").All(char.IsLetter))
                {
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input) || !input.Replace(" ", "").All(char.IsLetter))
                    {
                        this.ErrorPrint("Invalid input. Please enter only letters.");
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
        /// <summary>
        /// Method to input Ingredient Quantity, checks that input only contains doubles, with error handling
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public double IngredientQuantityInputMethod(string inputString)
        {
            double number = 0;
            bool isValidInput = false;

            Console.WriteLine(inputString);
            try
            {
                while (!isValidInput)
                {
                    string input = Console.ReadLine();

                    if (!double.TryParse(input, out number) || input.Contains("-") || number == 0)
                    {
                        this.ErrorPrint("Invalid input. Please enter a valid number.");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return number;
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input Measurement Unit, checks that input is not null and only contains letters, with error handling
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string MeasurementUnitInputMethod(string inputString)
        {
            string input = "";
            Console.WriteLine(inputString);
            try
            {
                while (string.IsNullOrEmpty(input) || !input.All(char.IsLetter))
                {
                    input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input) || !input.All(char.IsLetter))
                    {
                        this.ErrorPrint("Invalid input. Please enter only letters.");
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
        public int GetPositiveIntegerInput(string inputString)
        {
            int number = 0;
            bool isValidInput = false;

            Console.WriteLine(inputString);
            try
            {
                while (!isValidInput)
                {
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out number) || input.Contains("0") || !input.All(char.IsDigit))
                    {
                        this.ErrorPrint("Invalid input. Please enter a number.");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return number;
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