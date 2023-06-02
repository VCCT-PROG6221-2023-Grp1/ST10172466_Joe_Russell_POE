using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static PROG6221_POE_Part_1.Classes.RecipeClass;

namespace PROG6221_POE_Part_1.Classes
{
    internal class WorkerClass
    {
        /// <summary>
        /// Local Recipe Class Object
        /// </summary>
        public RecipeClass RecipeClassObjectHere = new RecipeClass();

        List<RecipeClass> RecipeList = new List<RecipeClass>();

        public int NumberOfRecipes { get; set; } = 0;


        //------- Part 2 Code -------
        /*public string name { get; set; } = string.Empty;
        
        1. The user shall be able to enter an unlimited number of recipes.
        2. The user shall be able to enter a name for each recipe. 
        3. The software shall display a list of all the recipes to the user in alphabetical order by name. 
        4. The user can choose which recipe to display from the list.


        !!Use This Somewhere!
        public (double, double, string) dasd

        return (0, 1, "dsa")
        */

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WorkerClass()
        {

        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to run the Recipe Class
        /// </summary>
        public void RunWorker()
        {
            this.MenuDisplay();            
            
            //------- Part 2 Code -------
            //CopyObject(RecipeClassObjectHere);
        }

        //-----------------------------------------------------------------------------------------------//
        public void MenuDisplay()
        {
            //Format Menu
            RecipeClassObjectHere.Format();

            //Switch statement input
            int option = RecipeClassObjectHere.GetPositiveIntegerInput("     Enter 1 to Enter Recipe Details" +
                "\n     Enter 2 to Search" +
                "\n     Enter 3 to Exit");

            //Prevents incorrect switch statement choice if there is no recipe
            if (RecipeList.Count == 0 && option > 1 && option < 3)
            {
                RecipeClassObjectHere.ErrorPrint("\r\nNo Recipe Entered");
                Console.ReadLine();
                Console.Clear();
                this.MenuDisplay();
            }

            switch (option)
            {
                case 1:
                    this.RecipeInput();
                    foreach (RecipeClass recipeClass in RecipeList)
                    {
                        Console.WriteLine(recipeClass.RecipeName);
                    }
                    break;
                case 2:
                    this.Display(this.RecipeSearch());
                    break;
                case 3:
                    //Exits application                    
                    Environment.Exit(0);
                    break;
                default:
                    RecipeClassObjectHere.ErrorPrint("Invalid option selected.");
                    Console.ReadLine();
                    break;
            }

            /*
            //Switch statement to access all program functions
            switch (option)
            {
                case 1:
                    //Runs input methods if recipe is empty
                    if (RecipeClassObjectHere.RecipeEntered == false)
                    {
                        RecipeClassObjectHere.GetRecipeIngredientInput();
                        RecipeClassObjectHere.GetRecipeStepInput();
                    }
                    else
                    {
                        RecipeClassObjectHere.ErrorPrint("\r\nAlready Entered Recipe");
                        Console.ReadLine();
                    }
                    break;
                case 2:
                    //Runs scaling method
                    RecipeClassObjectHere.ScaleRecipe();
                    break;
                case 3:
                    //Runs scale Reset method
                    RecipeClassObjectHere.ResetQuantity();
                    break;
                case 4:
                    //Runs display method
                    RecipeClassObjectHere.DisplayRecipe();
                    break;
                case 5:
                    //Runs delete recipe method
                    RecipeClassObjectHere.ClearRecipe();
                    break;
                case 6:
                    //Exits application                    
                    Environment.Exit(0);
                    break;
                default:
                    RecipeClassObjectHere.ErrorPrint("Invalid option selected.");
                    Console.ReadLine();
                    break;
            }
            */

            //Clear console for tidiness
            Console.Clear();
            this.MenuDisplay();
        }

        //-----------------------------------------------------------------------------------------------//
        //------- Part 2 Code -------
        //Method that does something, use if you can figure it out
        public RecipeClass CopyObject(RecipeClass recipeIn)
        {
            var newRecipe = new RecipeClass();
            newRecipe.RecipeName = recipeIn.RecipeName;
            return newRecipe;
        }

        //-----------------------------------------------------------------------------------------------//

        public void RecipeInput()
        {
            var recipe = new RecipeClass();

            //Assigns value to Number of Ingredients by calling input method
            this.NumberOfRecipes = RecipeClassObjectHere.GetPositiveIntegerInput("\r\nEnter Number of Recipes:");

            //For loop to populate Ingredient Array
            for (int i = 0; i < this.NumberOfRecipes; i++)
            {
                Console.WriteLine("Enter Recipe Name: ");
                recipe.RecipeName = Console.ReadLine();

                //Calling methods to input recipe values
                recipe.GetRecipeIngredientInput();
                recipe.GetRecipeStepInput();

                //Assigning values to Recipe List
                this.RecipeList.Add(recipe);
            }
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Display all Recipe Names and allow user to select a specific one
        /// </summary>
        /// <returns></returns>
        public RecipeClass RecipeSearch()
        {
            string searchname = string.Empty;
            RecipeList = RecipeList.OrderBy(RecipeClassObjectHere => RecipeClassObjectHere.RecipeName, StringComparer.OrdinalIgnoreCase).ToList();
            foreach (var recipe in RecipeList)
            {
                Console.WriteLine(recipe.RecipeName + "\n");
            }

            Console.WriteLine("Enter the name of the recipe you'd like to view: ");
            searchname = Console.ReadLine();
            RecipeClass foundRecipe = RecipeList.Find(RecipeClassObjectHere => RecipeClassObjectHere.RecipeName == searchname);

            if (foundRecipe != null)
            {
                return foundRecipe;
            }
            else
            {
                return null;
            }
        }

//-----------------------------------------------------------------------------------------------//
        /*public void RecipeDisplay()
        {
            RecipeList.Sort(RecipeList.Contains(RecipeClassObjectHere));
        }*/


//-----------------------------------------------------------------------------------------------//
        public void Display(RecipeClass recipe)
        {
            //Set the console foreground color to green
            Console.ForegroundColor = ConsoleColor.Green;

            //Displays the ingredients
            string ingredientDisplay = "";
            Console.WriteLine("\r\nThe " + recipe.RecipeName + " Recipe Requires:" +
                "\r\n--------------------------------------------------------------------------------------");

            //Reset the console foreground color
            Console.ResetColor();

            //Foreach loop to display ingredients
            foreach (IngredientClass ingredient in recipe.IngredientList)
            {
                ingredientDisplay += "- " + ingredient.IngredientQuantity.ToString() +
                    " " + ingredient.MeasurementUnit +
                    " of " + ingredient.IngredientName +
                    ", " + ingredient.CalorieAmount.ToString() + " Calorie(s)" +
                    ", " + ingredient.FoodGroup + " Food Group" +
                    "\r\n";
            }
            Console.WriteLine(ingredientDisplay);

            //Displays total calories of recipe
            Console.WriteLine("Total Calories: " + recipe.TotalCalories);

            //
            if (recipe.TotalCalories > 300)
            {
                recipe.ErrorPrint("\r\nWarning!!! Excessive Calories detected!");
            }

            //Set the console foreground color to green
            Console.ForegroundColor = ConsoleColor.Green;

            //Displays the steps
            string stepDisplay = "";
            Console.WriteLine("\r\nFollow these steps:" +
                "\r\n--------------------------------------------------------------------------------------");

            //Reset the console foreground color
            Console.ResetColor();

            //For loop to display the steps with step numbers using int i
            for (int i = 0; i < recipe.NumberOfSteps; i++)
            {
                stepDisplay += "Step " + (i + 1) + ": \r\n" +
                recipe.StepList[i].StepDescription + "\r\n\r\n";
            }
            Console.WriteLine(stepDisplay);
            Console.ReadLine();

//-----------------------------------------------------------------------------------------------//
        }
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//