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

        //------- Part 2 Code -------
        /// <summary>
        /// Local Conversion Class Object
        /// </summary>
        //public ConversionClass ConversionClassObjectHere = new ConversionClass();

        /// <summary>
        /// String that holds the Recipe Name
        /// </summary>
        public string RecipeName { get; set; } = string.Empty;

        /// <summary>
        /// Int that holds the number of ingredients
        /// </summary>
        public int NumberOfIngredients { get; set; } = 0;

        /// <summary>
        /// Int that holds the number of steps
        /// </summary>
        public int NumberOfSteps { get; set; } = 0;

        /// <summary>
        /// Double that holds the ammount that ingredients are scaled by
        /// </summary>
        public double ScaleFactor { get; set; } = 0;

        /// <summary>
        /// Bool that checks whether a recipe has been entered or not
        /// </summary>
        public bool RecipeEntered { get; set; } = false;

        /// <summary>
        /// Bool that checks whether a recipe has been scaled or not
        /// </summary>
        public bool Scaled { get; set; } = false;

        /// <summary>
        /// Bool that checks whether a recipe's scaling has been reset or not
        /// </summary>
        public bool ScaleReset { get; set; } = false;

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
            int option = GetPositiveIntegerInput("     Enter 1 to Enter Recipe Details" +
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
                    //Runs input methods if recipe is empty
                    if (this.RecipeEntered == false)
                    {
                        this.GetRecipeIngredientInput();
                        this.GetRecipeStepInput();
                    }
                    else
                    {
                        this.ErrorPrint("\r\nAlready Entered Recipe");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    //Runs scaling method
                    this.ScaleRecipe();
                    break;
                case 3:
                    //Runs scale Reset method
                    this.ResetQuantity();
                    break;
                case 4:
                    //Runs display method
                    this.DisplayRecipe();
                    break;
                case 5:
                    //Runs delete recipe method
                    this.ClearRecipe();
                    break;
                case 6:
                    //Exits application
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

        //Input Methods

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to get the Ingredient Inputs
        /// </summary>
        public void GetRecipeIngredientInput()
        {
            //Try-catch to handle errors
            try
            {
                //Assigns value to Recipe Name by calling input method
                this.RecipeName = this.RecipeNameInputMethod("\r\nEnter the Recipe Name:");

                //Assigns value to Number of Ingredients by calling input method
                this.NumberOfIngredients = GetPositiveIntegerInput("\r\nEnter Number of Ingredients:");

                //Initialises Ingredient Array
                this.IngredientArray = new IngredientClass[NumberOfIngredients];

                //For loop to populate Ingredient Array
                for (int i = 0; i < this.NumberOfIngredients; i++)
                {
                    var ingredients = new IngredientClass();

                    //Calling method to input ingredient values
                    IngredientClassObjectHere.IngredientInput();

                    //Assigning values to Ingredient Array
                    ingredients.IngredientName = this.IngredientClassObjectHere.IngredientName;
                    ingredients.IngredientQuantity = this.IngredientClassObjectHere.IngredientQuantity;
                    ingredients.MeasurementUnit = this.IngredientClassObjectHere.MeasurementUnit;
                    this.IngredientArray[i] = ingredients;
                }
                //Setting bool to true to prevent recipe from being entered again before being reset
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
                // Set the console foreground color to dark red then reset it after displaying a string
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("____________________________________________________________________");
                Console.ResetColor();

                //Assigns value to Number of Steps by calling input method
                this.NumberOfSteps = GetPositiveIntegerInput("\r\nEnter Number of Steps: ");

                //Initialises Step Array
                StepArray = new StepClass[this.NumberOfSteps];

                //For loop to populate Step Array
                for (int i = 0; i < this.NumberOfSteps; i++)
                {
                    var steps = new StepClass();

                    //Calling method to input step values
                    StepClassObjectHere.StepInput();

                    //Assigning values to Step Array
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

        //Scaling Methods

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to scale the Quantities
        /// </summary>
        public void ScaleRecipe()
        {
            //If statement checks to see if recipe has been scaled before
            if (this.Scaled == true)
            {
                this.ErrorPrint("\r\nAlready Scaled");
                Console.ReadLine();
                return;
            }

            //Sitch Statement input 
            int option = GetPositiveIntegerInput("\r\nEnter 1 for half, 2 for double or 3 for triple");

            //Prevents incorrect switch statement choice if input is out of bounds
            if (option > 3)
            {
                this.ErrorPrint("\r\nInvalid Input");
                Console.ReadLine();
                return;
            }

            //Try-catch to handle errors
            try
            {
                this.ScaleReset = true;

                //Save variables to different array
                switch (option)
                {
                    case 1:
                        //Halves Ingredient Quantities in array
                        foreach (IngredientClass ingredient in IngredientArray)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 0.5;

                            //------- Part 2 Code -------
                            /*this.ConversionClassObjectHere.CheckForUpdates(ingredient.IngredientQuantity, 0.5);

                            ingredient.IngredientQuantity = this.ConversionClassObjectHere.SelectedVolume;

                            ingredient.MeasurementUnit = this.ConversionClassObjectHere.SelectedUnit;

                            if (ingredient.IngredientQuantity >= 1000)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesUpwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);
                            }
                            else if (ingredient.IngredientQuantity < 1)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesDownwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);
                            }
                            if (this.ConversionClassObjectHere.IngredientQuantityHere != 0)
                            {
                                ingredient.IngredientQuantity = this.ConversionClassObjectHere.IngredientQuantityHere;
                                ingredient.MeasurementUnit = this.ConversionClassObjectHere.MeasurementUnitHere;
                            }*/
                        }

                        //Sets scale factor to 0.5 for calculations
                        this.ScaleFactor = 0.5;

                        //Setting bool to true to prevent recipe from being scaled again before scale has been reset
                        this.Scaled = true;
                        break;
                    case 2:
                        //Doubles Ingredient Quantities in array
                        foreach (IngredientClass ingredient in IngredientArray)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 2;

                            //------- Part 2 Code -------
                            /*if (ingredient.IngredientQuantity >= 1000)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesUpwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);
                            }
                            else if (ingredient.IngredientQuantity < 1)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesDownwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);                            
                            }

                            if (this.ConversionClassObjectHere.IngredientQuantityHere != 0)
                            {
                                ingredient.IngredientQuantity = this.ConversionClassObjectHere.IngredientQuantityHere;
                                ingredient.MeasurementUnit = this.ConversionClassObjectHere.MeasurementUnitHere;
                            }*/
                        }

                        //Sets scale factor to 2 for calculations
                        this.ScaleFactor = 2;

                        //Setting bool to true to prevent recipe from being scaled again before scale has been reset
                        this.Scaled = true;
                        break;
                    case 3:
                        foreach (IngredientClass ingredient in IngredientArray)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 3;

                            //------- Part 2 Code -------
                            /*if (ingredient.IngredientQuantity >= 1000)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesUpwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);
                            }
                            else if (ingredient.IngredientQuantity < 1)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesDownwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);
                            }

                            if (this.ConversionClassObjectHere.IngredientQuantityHere != 0)
                            {
                                ingredient.IngredientQuantity = this.ConversionClassObjectHere.IngredientQuantityHere;
                                ingredient.MeasurementUnit = this.ConversionClassObjectHere.MeasurementUnitHere;
                            }*/
                        }

                        //Sets scale factor to 3 for calculations
                        this.ScaleFactor = 3;

                        //Setting bool to true to prevent recipe from being scaled again before scale has been reset
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
            //If statement to prevent scale from being reset if it hasn't been scale before
            if (this.ScaleReset == false)
            {
                this.ErrorPrint("\r\nScale Recipe First");
                Console.ReadLine();
                return;
            }

            //Try-catch to handle errors
            try
            {
                this.Scaled = false;

                foreach (IngredientClass ingredient in IngredientArray)
                {
                    //Reverses scale operation
                    ingredient.IngredientQuantity = ingredient.IngredientQuantity / this.ScaleFactor;

                    //------- Part 2 Code -------
                    /*if (this.ScaleFactor == 0.5)
                    {
                        ingredient.IngredientQuantity = ingredient.IngredientQuantity / this.ScaleFactor;
                    }
                    else if (this.ScaleFactor == 0.5)
                    {
                        ingredient.IngredientQuantity = ingredient.IngredientQuantity / this.ScaleFactor;
                    }
                    else if (this.ScaleFactor == 0.5)
                    {

                    }*/
                }

                //Set the console foreground color to green then reset it after displaying string
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\n     Successfully Reset");
                Console.ResetColor();
                Console.ReadLine();

                //Prevent quantity being reset before being scaled again
                this.ScaleReset = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //-----------------------------------------------------------------------------------------------//

        //Display Recipe

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

            //Foreach loop to display ingredients
            foreach (IngredientClass ingredient in this.IngredientArray)
            {
                ingredientDisplay += "- " + ingredient.IngredientQuantity.ToString() +
                    " " + ingredient.MeasurementUnit +
                    " of " + ingredient.IngredientName + "\r\n";
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

            //For loop to display the steps with step numbers using int i
            for (int i = 0; i < this.NumberOfSteps; i++)
            {
                stepDisplay += "Step " + (i + 1) + ": \r\n" +
                this.StepArray[i].StepDescription + "\r\n\r\n";
            }
            Console.WriteLine(stepDisplay);
            Console.ReadLine();
        }

        //-----------------------------------------------------------------------------------------------//

        //Reset/Clear Recipe

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Reset Recipe
        /// </summary>
        public void ClearRecipe()
        {
            this.ErrorPrint("Are you sure you want to clear this recipe. Warning, this recipe will be permanently deleted!");

            //Switch statement input that prevents incorrect inputs
            int confirm = this.GetPositiveIntegerInput("Enter 1 to continue");

            //If statement that checks that the choice was confirmed, then resets the recipe
            if (confirm == 1)
            {
                this.NumberOfIngredients = 0;
                this.NumberOfSteps = 0;
                this.RecipeName = "";
                this.RecipeEntered = false;
                this.Scaled = false;

                Array.Clear(IngredientArray, 0, IngredientArray.Length);

                Array.Clear(StepArray, 0, StepArray.Length);

                // Set the console foreground color to green then reset it after displaying a string
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\n       Successfully Deleted");
                Console.ResetColor();
                Console.ReadLine();
            }
            else
            {
                this.ErrorPrint("\r\n       Cancelled");
                Console.ReadLine();
            }
        }

        //-----------------------------------------------------------------------------------------------//

        //Error Handling Methods

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input Recipe Name, checks that input only contains letters and spaces, with error handling
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string RecipeNameInputMethod(string inputString)
        {
            //Holds the input
            string input = "";

            //Displays the text
            Console.WriteLine(inputString);

            //Try-catch to handle errors
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
        /// Method that accepts a string and returns a positive int, with error handling
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

            //Try-catch to handle errors
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

        //Format Methods

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
        //-----------------------------------------------------------------------------------------------//
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//