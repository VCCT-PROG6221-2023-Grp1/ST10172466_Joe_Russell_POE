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
            //this.IngredientName = this.IngredientNameInput();
            this.IngredientName = this.GetValidString();

            Console.WriteLine("\r\nPlease enter the Quantity of the Ingredient: ");
            this.IngredientQuantity = IngredientQuantityInput(Console.ReadLine());

            this.MeasurementUnit = this.MeasurementUnitInput();
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
                    Console.WriteLine("Invalid input. Please enter a non-null string.");
                }
                else if (!input.All(c => char.IsLetter(c) || c == ' '))
                {
                    Console.WriteLine("Invalid input. Please enter a string containing only letters and spaces.");
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
                        Console.WriteLine("Input can only contain letters.");
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
                    ingNum = int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Please only enter digits\r\n");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ingNum;
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
                        Console.WriteLine("Input can only contain letters.");
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
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//