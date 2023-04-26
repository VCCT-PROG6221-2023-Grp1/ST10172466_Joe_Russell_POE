using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    /*
     * To Do List:
     * - Inquire about try catch, while loop, error handling
     * - Ask Aiden about counter for foreach loops
     * - Scale array that holds original values, foreach loop in reset value method
     */

    internal class RecipeClass
    {
        /// <summary>
        /// Ingredient Class Array
        /// </summary>
        IngredientClass[] IngredientArray;

        IngredientClass[] TempIngredientArray;

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
            int option = GetIntegerInputFromUser("Enter 1 to enter Recipe Details" +
                "\nEnter 2 to Scale Recipe Quantity Values" +
                "\nEnter 3 to Reset Quantity Values" +
                "\nEnter 4 to View Recipe" +
                "\nEnter 5 to Clear All Values" +
                "\nEnter 6 to Exit");

            //Prevents incorrect switch statement choice if there is no recipe
            if (this.RecipeName.Equals("") && option > 1 && option < 6)
            {
                Console.WriteLine("No Recipe Entered");
                Console.ReadLine();
                Console.Clear();
                RunRecipe();
            }

            //Switch statement to access all program functions
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
                    this.ResetQuantity();
                    //this.CopyObject(new RecipeClass());
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
                    Console.WriteLine("Invalid option selected.");
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
            int option = GetIntegerInputFromUser("\r\nEnter 1 for half, 2 for double or 3 for triple");

            try
            {
                TempIngredientArray = new IngredientClass[this.NumberOfIngredients];

                //Save variables to different array
                if (this.ScaleCounter == 0)
                {
                    Console.WriteLine("Test");
                    Console.ReadLine();

                    for (int i = 0; i < this.NumberOfIngredients; i++)
                    {
                        var ingredients = new IngredientClass();                        
                        ingredients.IngredientName = this.IngredientClassObjectHere.IngredientName;
                        ingredients.IngredientQuantity = this.IngredientClassObjectHere.IngredientQuantity;
                        ingredients.MeasurementUnit = this.IngredientClassObjectHere.MeasurementUnit;
                        TempIngredientArray[i] = ingredients;                        
                    }

                }


                switch (option)
                {
                    case 1:
                        foreach (IngredientClass ingredient in IngredientArray)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 0.5;
                        }
                        this.ScaleFactor = 0.5;
                        this.ScaleCounter++;
                        /*for (int i = 0; i < this.NumberOfIngredients; i++)
                        {
                            IngredientArray[i].IngredientQuantity = IngredientArray[i].IngredientQuantity * 0.5;
                        }*/
                        break;
                    case 2:
                        this.ScaleFactor = 2;
                        this.ScaleCounter++;

                        for (int i = 0; i < this.NumberOfIngredients; i++)
                        {
                            IngredientArray[i].IngredientQuantity = IngredientArray[i].IngredientQuantity * 2;
                        }
                        break;
                    case 3:
                        this.ScaleFactor = 3;
                        this.ScaleCounter++;

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
            catch (Exception ex)
            {

            }

        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Display Recipe Ingredients and Steps
        /// </summary>
        public void DisplayRecipe()
        {
            //Displays the ingredients
            string ingredientDisplay = "";
            Console.WriteLine("\r\nThe " + this.RecipeName + " Recipe Requires:" +
                "\r\n--------------------------------------------------------------------------------------");

            for (int i = 0; i < this.NumberOfIngredients; i++)
            {
                ingredientDisplay += "- " + IngredientArray[i].IngredientQuantity.ToString() +
                    " " + IngredientArray[i].MeasurementUnit +
                    " of " + IngredientArray[i].IngredientName + "\r\n";
            }
            Console.WriteLine(ingredientDisplay);

            //Displays the steps
            string stepDisplay = "";
            Console.WriteLine("\r\nFollow these steps:" +
                "\r\n--------------------------------------------------------------------------------------");
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
        /// Method to Reset Quantity Values
        /// </summary>
        /// <param name="recipeIn"></param>
        /// <returns></returns>
        public void ResetQuantity()
        {
            try
            {
                for (int i = 0; i < this.NumberOfIngredients; i++)
                {
                    IngredientArray[i].IngredientQuantity = TempIngredientArray[i].IngredientQuantity;
                }

                /*for (int i = 0; i < this.ScaleCounter; i++)
                {
                    foreach (IngredientClass ingredient in IngredientArray)
                    {
                        if (this.ScaleFactor == 0.5)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity / this.ScaleFactor;
                        }
                        else
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * this.ScaleFactor;
                        }
                    }
                }*/
            }
            catch(Exception ex) 
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
        /// Method to Reset Recipe
        /// </summary>
        public void ClearRecipe()
        {
            this.NumberOfIngredients = 0;
            this.NumberOfSteps = 0;
            this.RecipeName = "";

            Array.Clear(IngredientArray, 0, IngredientArray.Length);

            Array.Clear(StepArray, 0, StepArray.Length);
        }
        
        //-----------------------------------------------------------------------------------------------//

                                         //Error Handling & Format Methods

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Checks that string input contains only digits
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
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

        public string OnlyDigits(string inputString)
        {
            string input = "";
            bool isOnlyDigits = false;

            try
            {
                while (isOnlyDigits)
                {
                    Console.WriteLine(inputString);
                    input = Console.ReadLine();

                    if (input.All(char.IsDigit))
                    {
                        isOnlyDigits = true;
                    }
                    else
                    {
                        Console.WriteLine("Please only enter digits\r\n");
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

                if (!int.TryParse(input, out number) || input.Contains("0") || !input.All(char.IsDigit))
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

    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//