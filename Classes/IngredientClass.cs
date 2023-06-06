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

        public double CalorieAmount { get; set; } = 0;

        public string FoodGroup { get; set; } = string.Empty;

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
            // Set the console foreground color to dark red and reset it after displaying a string
            Console.ForegroundColor = ConsoleColor.DarkRed;          
            Console.WriteLine("____________________________________________________________________");
            Console.ResetColor();

            //Assigns value to Ingredient Name by calling input method
            this.IngredientName = this.IngredientNameInputMethod("\r\nPlease enter the Ingredient Name:");

            // Set the console foreground color to dark cyan and reset it after displaying a string
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\r\nChoose Measurement Unit:");            
            Console.ResetColor();

            //Switch statement input to choose Measurement Unit type
            int option = GetPositiveIntegerInput("\r\n       Enter 1 for Millilitres" +
                "\r\n       Enter 2 for Grams" +
                "\r\n       Enter 3 for Other");

            //Prevents incorrect switch statement choice
            while (option > 3)
            {
                this.ErrorPrint("\r\nInvalid Input. Please enter a valid number.");
                option = this.GetPositiveIntegerInput(Console.ReadLine());
            }

            //Switch statement to assign Measurement Unit value   
            switch (option)
            {
                case 1:
                    this.MeasurementUnit = "Millilitre(s)";
                    break;
                case 2:
                    this.MeasurementUnit = "Gram(s)";
                    break;
                case 3:
                    this.MeasurementUnit = this.MeasurementUnitInputMethod("\r\nPlease enter a custom Measurement Unit:"); ;
                    break;
                default:
                    this.ErrorPrint("Invalid option selected.");
                    Console.ReadLine();
                    break;
            }

            //Assigns value to Ingredient Quantity by calling input method
            this.IngredientQuantity = this.IngredientQuantityInputMethod("\r\nPlease enter the Quantity of the Ingredient:");

            //Assigns value to Calory Amount by calling input method
            this.CalorieAmount = this.CalorieAmountInputMethod("\r\nPlease enter the Amount of Calories the Ingredient contains:");

            //Assigns value to Food Group by calling input method
            this.FoodGroupInputMethod();
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
                //While input is empty or while it contains digits or symbols, user is prompted for valid input
                while (string.IsNullOrWhiteSpace(input) || !input.Replace(" ", "").All(char.IsLetter))
                {
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input) || !input.Replace(" ", "").All(char.IsLetter))
                    {
                        this.ErrorPrint("Invalid input. Please only enter letters.");
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
            //Holds the input
            double number = 0;
            bool isValidInput = false;

            //Displays the text
            Console.WriteLine(inputString);
            try
            {
                //While input is not a double or while it contains 0 or a negative number, user is prompted for valid input
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
            //Holds the input
            string input = "";

            //Displays the text
            Console.WriteLine(inputString);
            try
            {
                //While input is empty or while it contains digits or symbols, user is prompted for valid input
                while (string.IsNullOrEmpty(input) || !input.All(char.IsLetter))
                {
                    input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input) || !input.All(char.IsLetter))
                    {
                        this.ErrorPrint("Invalid input. Please only enter letters.");
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
        /// Method to input Calorie Amount, checks that input only contains doubles, with error handling
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public double CalorieAmountInputMethod(string inputString)
        {
            //Holds the input
            double number = 0;
            bool isValidInput = false;

            //Displays the text
            Console.WriteLine(inputString);
            try
            {
                //While input is not a double or while it contains 0 or a negative number, user is prompted for valid input
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
        /// Method to input Ingredient Food Group, checks that input is not null and only contains letters, with error handling
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public void FoodGroupInputMethod()
        {
            // Set the console foreground color to dark cyan and reset it after displaying a string
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\r\nChoose Food Group:");
            Console.ResetColor();

            //Switch statement input to choose Measurement Unit type
            int option = GetPositiveIntegerInput("\r\n       Enter 1 for Fruits" +
                "\r\n       Enter 2 for Vegetables" +
                "\r\n       Enter 3 for Grains" +
                "\r\n       Enter 4 for Protein Foods" +
                "\r\n       Enter 5 for Dairy");

            //Prevents incorrect switch statement choice
            while (option > 5)
            {
                this.ErrorPrint("\r\nInvalid Input. Please enter a valid number.");
                option = this.GetPositiveIntegerInput(Console.ReadLine());
            }

            //Switch statement to assign Food Group value   
            switch (option)
            {
                case 1:
                    this.FoodGroup = "Fruits";
                    break;
                case 2:
                    this.FoodGroup = "Vegetables";
                    break;
                case 3:
                    this.FoodGroup = "Grains";
                    break;
                case 4:
                    this.FoodGroup = "Protein Foods";
                    break;
                case 5:
                    this.FoodGroup = "Dairy";
                    break;
                default:
                    this.ErrorPrint("Invalid option selected.");
                    Console.ReadLine();
                    break;
            }
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input a number that checks that the number is a positive integer and returns it, with error handling
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public int GetPositiveIntegerInput(string inputString)
        {
            //Holds the input
            int number = 0;
            bool isValidInput = false;

            //Displays the text
            Console.WriteLine(inputString);
            try
            {
                //While input is not a double or while it contains 0 or a negative number, user is prompted for valid input
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