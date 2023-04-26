using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    /*
     * To Do List:
     * 
     */

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

        public int ScaleCounter { get; set; } = 0;

        public double ScaleFactor { get; set; } = 0;

        public bool RecipeEntered { get; set; } = false;

        public bool Scaled { get; set; } = false;

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
            //Format Menu
            this.Format();

            //Switch statement input
            int option = GetIntegerInputFromUser("     Enter 1 to enter Recipe Details" +
                "\n     Enter 2 to Scale Recipe Quantity Values" +
                "\n     Enter 3 to Reset Quantity Values" +
                "\n     Enter 4 to View Recipe" +
                "\n     Enter 5 to Clear All Values" +
                "\n     Enter 6 to Exit");

            //Prevents incorrect switch statement choice if there is no recipe
            if (this.RecipeName.Equals("") && option > 1 && option < 6)
            {
                this.ErrorPrint("\r\nNo Recipe Entered");
                Console.ReadLine();
                Console.Clear();
                RunRecipe();
            }

            //Switch statement to access all program functions
            switch (option)
            {
                case 1:
                    if (this.RecipeEntered == false)
                    {
                        this.GetRecipeInput();
                        this.GetRecipeStepInput();
                    }
                    else
                    {
                        this.ErrorPrint("\r\nAlready Entered Recipe");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    this.ScaleRecipe();
                    break;
                case 3:
                    this.ResetQuantity();
                    break;
                case 4:
                    this.DisplayRecipe();
                    break;
                case 5:
                    this.ClearRecipe();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    this.ErrorPrint("Invalid option selected.");
                    Console.ReadLine();
                    break;
            }

            //Clear console for tidiness
            Console.Clear();
            this.RunRecipe();

        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to get the Ingredient Inputs
        /// </summary>
        public void GetRecipeInput()
        {
            //Try-catch to handle errors
            try
            {
                this.RecipeName = this.RecipeNameInput();
                //this.RecipeName = GetStringInputFromUser("\r\nEnter Recipe Name:");
                this.NumberOfIngredients = GetIntegerInputFromUser("\r\nEnter Number of Ingredients:");

                this.IngredientArray = new IngredientClass[NumberOfIngredients];

                for (int i = 0; i < this.NumberOfIngredients; i++)
                {
                    var ingredients = new IngredientClass();
                    IngredientClassObjectHere.IngredientInput();
                    ingredients.IngredientName = this.IngredientClassObjectHere.IngredientName;
                    ingredients.IngredientQuantity = this.IngredientClassObjectHere.IngredientQuantity;
                    ingredients.MeasurementUnit = this.IngredientClassObjectHere.MeasurementUnit;
                    this.IngredientArray[i] = ingredients;
                }

                this.RecipeEntered = true;
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
            //Try-catch to handle errors
            try
            {
                Console.WriteLine("--------------------------------------------------------------------------------------");
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
        /// Method to scale the Quantities
        /// </summary>
        public void ScaleRecipe()
        {
            if (this.Scaled == true)
            {
                this.ErrorPrint("\r\nAlready Scaled");
                Console.ReadLine();
                return;
            }

            int option = GetIntegerInputFromUser("\r\nEnter 1 for half, 2 for double or 3 for triple");

            try
            {
                //Save variables to different array
                switch (option)
                {
                    case 1:
                        foreach (IngredientClass ingredient in IngredientArray)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 0.5;
                        }
                        this.ScaleFactor = 0.5;

                        this.Scaled = true;

                        this.ScaleCounter++;
                        break;
                    case 2:
                        foreach (IngredientClass ingredient in IngredientArray)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 2;
                        }
                        this.ScaleFactor = 2;

                        this.Scaled = true;

                        this.ScaleCounter++;
                        break;
                    case 3:
                        foreach (IngredientClass ingredient in IngredientArray)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 3;
                        }
                        this.ScaleFactor = 3;
                        this.Scaled = true;
                        break;
                    default:
                        this.ErrorPrint("Invalid option selected.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Reset Quantity Values
        /// </summary>
        /// <param name="recipeIn"></param>
        /// <returns></returns>
        public void ResetQuantity()
        {
            try
            {
                this.Scaled = false;

                foreach (IngredientClass ingredient in IngredientArray)
                {
                    if (this.ScaleFactor == 0.5)
                    {
                        ingredient.IngredientQuantity = ingredient.IngredientQuantity / this.ScaleFactor;
                    }
                    else
                    {
                        ingredient.IngredientQuantity = ingredient.IngredientQuantity / this.ScaleFactor;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public RecipeClass CopyObject(RecipeClass recipeIn)
        {
            var newRecipe = new RecipeClass();
            newRecipe.name = recipeIn.name;
            return newRecipe;
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Display Recipe Ingredients and Steps
        /// </summary>
        public void DisplayRecipe()
        {
            //Set the console foreground color to green
            Console.ForegroundColor = ConsoleColor.Green;

            //Displays the ingredients
            string ingredientDisplay = "";
            Console.WriteLine("\r\nThe " + this.RecipeName + " Recipe Requires:" +
                "\r\n--------------------------------------------------------------------------------------");

            //Reset the console foreground color
            Console.ResetColor();

            for (int i = 0; i < this.NumberOfIngredients; i++)
            {
                ingredientDisplay += "- " + IngredientArray[i].IngredientQuantity.ToString() +
                    " " + IngredientArray[i].MeasurementUnit +
                    " of " + IngredientArray[i].IngredientName + "\r\n";
            }
            Console.WriteLine(ingredientDisplay);

            //Set the console foreground color to green
            Console.ForegroundColor = ConsoleColor.Green;

            //Displays the steps
            string stepDisplay = "";
            Console.WriteLine("\r\nFollow these steps:" +
                "\r\n--------------------------------------------------------------------------------------");

            //Reset the console foreground color
            Console.ResetColor();

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
        /// Method to Reset Recipe
        /// </summary>
        public void ClearRecipe()
        {
            this.ErrorPrint("Are you sure you want to clear this recipe. Warning, this recipe will be permanently deleted!");

            int confirm = this.GetIntegerInputFromUser("Enter 1 to continue");

            if (confirm == 1)
            {
                this.NumberOfIngredients = 0;
                this.NumberOfSteps = 0;
                this.RecipeName = "";
                this.RecipeEntered = false;
                this.Scaled = false;

                Array.Clear(IngredientArray, 0, IngredientArray.Length);

                Array.Clear(StepArray, 0, StepArray.Length);
            }
        }

        //-----------------------------------------------------------------------------------------------//

        //Error Handling & Format Methods

        //-----------------------------------------------------------------------------------------------//
        public string RecipeNameInput()
        {
            Console.WriteLine("\r\nEnter Recipe Name:");
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
                    this.ErrorPrint("\r\nInput cannot be null");
                    this.RecipeNameInput();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
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

                if (!int.TryParse(input, out number) || input.Contains("0") || !input.All(char.IsDigit))
                {
                    this.ErrorPrint("Invalid input. Please enter a number.");
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
        /// Method to Format Console Menu
        /// </summary>
        public void Format()
        {
            // Set the console foreground color to gray
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(@" (                          (                                      
");

            // Set the console foreground color to dark red
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(@" )\ )                       )\ )                                                
");
            // Set the console foreground color to dark yellow
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