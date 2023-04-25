using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    internal class RecipeClass
    {
        /// <summary>
        /// Ingredient Class Array
        /// </summary>
        IngredientClass[] IngredientArray;

        /// <summary>
        /// Step Class Array
        /// </summary>
        StepClass[] StepArray;

        /// <summary>
        /// Local Ingredient Class Object
        /// </summary>
        public IngredientClass IngredientClassObjectHere = new IngredientClass();

        /// <summary>
        /// Local Step Class Object
        /// </summary>
        public StepClass StepClassObjectHere = new StepClass();

        /// <summary>
        /// String that holds the Recipe Name
        /// </summary>
        public string RecipeName { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public int NumberOfIngredients { get; set; } = 0;

        public int NumberOfSteps { get; set; } = 0;

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default constructor
        /// </summary>
        public RecipeClass()
        {

        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to run Recipe Class
        /// </summary>
        public void RunRecipe()
        {
            this.Format();

            int option = GetIntegerInputFromUser("Enter 1 to enter Recipe Details" +
                "\nEnter 2 to Scale Recipe Quantity Values" +
                "\nEnter 3 to Reset Quantity Values" +
                "\nEnter 4 to View Recipe" +
                "\nEnter 5 to Clear All Values" +
                "\nEnter 6 to Exit");

            if (this.RecipeName.Equals("") && option > 1 && option < 6)
            {
                Console.WriteLine("No Recipe Entered");
                Console.ReadLine();
                Console.Clear();                 
                RunRecipe();
            }

            switch (option)
            {
                case 1:
                    this.GetRecipeInput();
                    this.GetRecipeStepInput();
                    break;
                case 2:
                    this.ScaleRecipe();
                    break;
                case 3:
                    this.CopyObject(new RecipeClass());
                    break;
                case 4:
                    this.DisplayRecipe();
                    break;
                case 5:
                    this.ResetRecipe();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option selected.");
                    Console.ReadLine();
                    break;
            }
            Console.Clear();
            this.RunRecipe();

        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to get the Ingredient Inputs
        /// </summary>
        public void GetRecipeInput()
        {
            try
            {
                RecipeName = GetStringInputFromUser("\r\nEnter Recipe Name:");
                NumberOfIngredients = GetIntegerInputFromUser("\r\nEnter Number of Ingredients:");

                IngredientArray = new IngredientClass[NumberOfIngredients];

                for (int i = 0; i < this.NumberOfIngredients; i++)
                {
                    var ingredients = new IngredientClass();
                    IngredientClassObjectHere.IngredientInput();
                    ingredients.IngredientName = this.IngredientClassObjectHere.IngredientName;
                    ingredients.IngredientQuantity = this.IngredientClassObjectHere.IngredientQuantity;
                    ingredients.MeasurementUnit = this.IngredientClassObjectHere.MeasurementUnit;
                    IngredientArray[i] = ingredients;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to get the Step Inputs
        /// </summary>
        public void GetRecipeStepInput()
        {
            try
            {
                this.NumberOfSteps = GetIntegerInputFromUser("\r\nEnter Number of Steps: ");

                StepArray = new StepClass[this.NumberOfSteps];

                for (int i = 0; i < this.NumberOfSteps; i++)
                {
                    var steps = new StepClass();
                    StepClassObjectHere.StepInput();
                    steps.StepDescription = this.StepClassObjectHere.StepDescription;
                    StepArray[i] = steps;
                }
            }
            catch (System.Exception ex) 
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Display Recipe Ingredients and Steps
        /// </summary>
        public void DisplayRecipe()
        {
            string ingDisplay = "";
            Console.WriteLine("\r\nThe " + this.RecipeName + " Recipe Requires:" +
                "\r\n___________________________________________________________________________________________________________________");

            for (int i = 0; i < this.NumberOfIngredients; i++)
            {
                ingDisplay += "- " + IngredientArray[i].IngredientQuantity.ToString() +
                    " " + IngredientArray[i].MeasurementUnit +
                    " of " + IngredientArray[i].IngredientName + "\r\n";
            }
            Console.WriteLine(ingDisplay);

            string stepDisplay = "";
            Console.WriteLine("\r\nFollow these steps:" +
                "\r\n___________________________________________________________________________________________________________________");
            for (int i = 0; i < this.NumberOfSteps; i++)
            {
                stepDisplay += "Step " + (i + 1) + ": \r\n" +
                    StepArray[i].StepDescription + "\r\n\r\n";
            }
            Console.WriteLine(stepDisplay);


            Console.ReadLine();
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to scale the Quantities
        /// </summary>
        public void ScaleRecipe()
        {
            int option = GetIntegerInputFromUser("\r\nEnter 1 for half, 2 for double or 3 for triple");

            switch (option)
            {
                case 1:
                    for (int i = 0; i < this.NumberOfIngredients; i++)
                    {
                        IngredientArray[i].IngredientQuantity = IngredientArray[i].IngredientQuantity * 0.5;
                    }
                    break;
                case 2:
                    for (int i = 0; i < this.NumberOfIngredients; i++)
                    {
                        IngredientArray[i].IngredientQuantity = IngredientArray[i].IngredientQuantity * 2;
                    }
                    break;
                case 3:
                    for (int i = 0; i < this.NumberOfIngredients; i++)
                    {
                        IngredientArray[i].IngredientQuantity = IngredientArray[i].IngredientQuantity * 3;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }

        }

        //-----------------------------------------------------------------------------------------------//
        public int IntErrorHandling(string input)
        {
            int ingNum = 0;
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
        /// Method to Reset Quantity Values
        /// </summary>
        /// <param name="recipeIn"></param>
        /// <returns></returns>
        public RecipeClass CopyObject(RecipeClass recipeIn)
        {
            var newRecipe = new RecipeClass();

            newRecipe.name = recipeIn.name;

            return newRecipe;
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Reset Recipe
        /// </summary>
        public void ResetRecipe()
        {
            this.NumberOfIngredients = 0;
            this.NumberOfSteps = 0;
            this.RecipeName = "";

            int[] numbers = new int[] { 1, 2, 3, 4, 5 };

            // reset the array by creating a new instance of it
            int[] newNumbers = new int[5];
            numbers = newNumbers;
        }

        //-----------------------------------------------------------------------------------------------//
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
                    Console.WriteLine("Invalid input. Please enter only letters.");
                }
                else
                {
                    isValidInput = true;
                }
            } while (!isValidInput);

            return input;
        }

        //-----------------------------------------------------------------------------------------------//
        public int GetIntegerInputFromUser(string inputString)
        {
            int number;
            bool isValidInput = false;

            do
            {
                Console.WriteLine(inputString);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out number))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
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
        /// Method to Format Console
        /// </summary>
        public void Format()
        {

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(@" (                          (                                      
");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(@" )\ )                       )\ )                                                
");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"(()/(  (    (          (   (()/((        (  ( (      )    )    
 /(_))))\ ( )\ `  )   ))\   /(_))(   (   )\))()(  ( /(   (                       
");

            // Set the console foreground color to yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@"(_)) /((_))((_)/(/(  /((_) (_))(()\  )\ ((_))(()\ )(_))  )\  ' 
| _ (_)) ((_|_|(_)_\(_))   | _ \((_)((_) (()(_|(_|(_)_ _((_))  
|   / -_) _|| | '_ \) -_)  |  _/ '_/ _ \/ _` | '_/ _` | '  \() 
");

            // Reset the console foreground color
            Console.ResetColor();

            // Display the ASCII art
            Console.Write(@"|_|_\___\__||_| .__/\___|  |_| |_| \___/\__, |_| \__,_|_|_|_|  
              |_|                       |___/
");

            Console.WriteLine("___________________________________________________________________________________________________________________\r\n");
        }

    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//