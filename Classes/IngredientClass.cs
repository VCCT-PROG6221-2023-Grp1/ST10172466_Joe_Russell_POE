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

            this.IngredientName = this.IngredientNameInput();

            Console.WriteLine("\r\nPlease enter the Quantity of the Ingredient: ");
            this.IngredientQuantity = double.Parse(Console.ReadLine());

            this.MeasurementUnit = this.MeasurementUnitInput();
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input Ingredient Name with error checking
        /// </summary>
        /// <returns></returns>
        public string IngredientNameInput()
        {
            Console.WriteLine("\r\nPlease enter the Name of the Ingredient: ");
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