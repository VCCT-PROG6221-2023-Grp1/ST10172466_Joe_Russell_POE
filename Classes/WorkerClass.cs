using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static PROG6221_POE_Part_1.Classes.RecipeClass;

namespace PROG6221_POE_Part_1.Classes
{
    public class WorkerClass
    {
        /// <summary>
        /// Local Recipe Class Object
        /// </summary>
        public RecipeClass RecipeClassObjectHere = new RecipeClass();

        /// <summary>
        /// Recipe Class List
        /// </summary>
        public List<RecipeClass> RecipeList = new List<RecipeClass>();

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
            //Calling method to display main menu of the application
            this.MainMenu();
        }

        //-----------------------------------------------------------------------------------------------//

        //Main Menu

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Menu that displays program functions
        /// </summary>
        public void MainMenu()
        {
            //Format Menu
            RecipeClassObjectHere.Format();

            //Try-catch to handle errors
            try
            {
                //Switch statement input to choose whether to add new recipe or search recipes
                int option = RecipeClassObjectHere.GetPositiveIntegerInput("     Enter 1 to Add Recipe" +
                    "\n     Enter 2 to Search/View More Options for Recipe" +
                    "\n     Enter 3 to Exit");

                //Prevents incorrect switch statement choice
                while (option > 3)
                {
                    RecipeClassObjectHere.ErrorPrint("\r\nInvalid Input. Please enter a valid number.");
                    option = RecipeClassObjectHere.GetPositiveIntegerInput(Console.ReadLine());
                }

                switch (option)
                {
                    case 1:
                        //Calling method to add new recipe
                        this.AddRecipe();
                        break;
                    case 2:
                        //Calling method to search for existing recipes
                        this.SearchRecipe();
                        break;
                    case 3:
                        //Exit the program
                        Environment.Exit(0);
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.Clear();
            this.MainMenu();
        }

        //-----------------------------------------------------------------------------------------------//

        //Add Recipe to List

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to add a new recipe
        /// </summary>
        public void AddRecipe()
        {
            //Creating recipe class instance
            RecipeClass recipe = new RecipeClass();

            //Try-catch to handle errors
            try
            {
                string recipeNameInput = string.Empty;
                bool foundMatch = false;

                //Assigns value to temporary input by calling input method
                recipeNameInput = RecipeClassObjectHere.RecipeNameInputMethod("\r\nEnter the Recipe Name: ");

                //Foreach loop to ensure that recipe names are unique
                foreach (RecipeClass test in this.RecipeList)
                {
                    if (test.RecipeName.Equals(recipeNameInput, StringComparison.OrdinalIgnoreCase))
                    {
                        foundMatch = true;
                        RecipeClassObjectHere.ErrorPrint("\r\nPlease enter a unique Recipe Name");
                        this.AddRecipe();
                    }
                }

                //Assigns value to Recipe Name if input is unique
                if (!foundMatch)
                {
                    recipe.RecipeName = recipeNameInput;
                }

                //Set the console foreground color to magenta and reset it after displaying a string
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("_______________________________________________________________________________________");
                Console.ResetColor();

                //Assigns value to Number of Ingredients by calling input method
                int numberOfIngredients = RecipeClassObjectHere.GetPositiveIntegerInput("\r\nEnter Number of Ingredients: ");

                //For loop to input ingredient values
                for (int i = 0; i < numberOfIngredients; i++)
                {
                    recipe.GetRecipeIngredientInput();
                }

                //Set the console foreground color to magenta and reset it after displaying a string
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("_______________________________________________________________________________________");
                Console.ResetColor();

                //Assigns value to Number of Steps by calling input method
                int numberOfSteps = RecipeClassObjectHere.GetPositiveIntegerInput("\r\nEnter Number of Steps: ");

                //For loop to input step values
                for (int i = 0; i < numberOfSteps; i++)
                {
                    recipe.GetRecipeStepInput();
                }

                //Adding a new recipe to Recipe List
                RecipeList.Add(recipe);

                // Set the console foreground color to green then reset it after displaying a string
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\n     Recipe Added Successfully");
                Console.ResetColor();
                Console.ReadLine();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //-----------------------------------------------------------------------------------------------//

        //Search Recipes

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method that displays all recipe names and allows users to select one
        /// </summary>
        public void SearchRecipe()
        {
            //Try-catch to handle errors
            try
            {
                //Ensures that a search can only be done if there is a pre-existing recipe
                if (RecipeList.Count == 0)
                {
                    RecipeClassObjectHere.ErrorPrint("\r\n     No Recipes Found");
                    Console.ReadLine();
                    return;
                }

                //Set the console foreground color to dark cyan and reset it after displaying a string
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("========= Recipes =========");
                Console.ResetColor();

                //Foreach loop to print alphabetised list of recipe names
                foreach (var recipe in RecipeList.OrderBy(r => r.RecipeName))
                {
                    Console.WriteLine("   - " + recipe.RecipeName);
                }

                // Set the console foreground color to dark cyan and reset it after displaying a string
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("===========================");
                Console.ResetColor();


                //Search Input
                Console.WriteLine("\r\nEnter the name of the recipe you want to select: ");
                string recipeName = Console.ReadLine();

                //Selecting specific recipe using LINQ
                RecipeClass selectedRecipe = RecipeList.FirstOrDefault(r => r.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

                //Error Handling
                if (selectedRecipe != null)
                {
                    //Display recipe
                    selectedRecipe.DisplayRecipe();

                    Console.Clear();

                    //Show New Menu
                    RecipeMenu(selectedRecipe);
                }
                else
                {
                    RecipeClassObjectHere.ErrorPrint("\r\nRecipe not found. Please ensure that a recipe with that name exists.");
                    Console.ReadLine();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.Clear();
        }

        //-----------------------------------------------------------------------------------------------//

        //Show Search Recipe Menu

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method that displays a menu that allows users to interact with a specific recipe
        /// </summary>
        /// <param name="recipe"></param>
        private void RecipeMenu(RecipeClass recipe)
        {
            //Format Menu
            RecipeClassObjectHere.Format();

            //Try-catch to handle errors
            try
            {
                //Switch statement input
                int option = RecipeClassObjectHere.GetPositiveIntegerInput("     Enter 1 to Scale Recipe Quantity Values" +
                    "\n     Enter 2 to Reset Quantity Values" +
                    "\n     Enter 3 to View Recipe" +
                    "\n     Enter 4 to Delete Recipe" +
                    "\n     Enter 5 to Return to Main Menu");

                switch (option)
                {
                    case 1:
                        //Calls method to scale quantity values
                        recipe.ScaleRecipe();
                        break;
                    case 2:
                        //Calls method to reset quantity values to original
                        recipe.ResetQuantity();
                        break;
                    case 3:
                        //Calls method to display Recipe
                        recipe.DisplayRecipe();
                        break;
                    case 4:
                        //Calls method to delete Recipe
                        DeleteRecipe(recipe);
                        return;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.Clear();
            this.RecipeMenu(recipe);
        }
        //-----------------------------------------------------------------------------------------------//

        //Delete Recipe

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Delete Specific Recipe from Recipe List
        /// </summary>
        /// <param name="recipe"></param>
        public void DeleteRecipe(RecipeClass recipe)
        {
            RecipeClassObjectHere.ErrorPrint("\r\nAre you sure you want to clear this recipe. Warning, this recipe will be permanently deleted!");

            //Try-catch to handle errors
            try
            {
                //Switch statement input that prevents incorrect inputs
                int confirm = RecipeClassObjectHere.GetPositiveIntegerInput("Enter 1 to continue");

                //If statement that checks that the choice was confirmed, then resets the recipe
                if (confirm == 1)
                {
                    RecipeList.Remove(recipe);

                    // Set the console foreground color to green then reset it after displaying a string
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\r\n     Successfully Deleted");
                    Console.ResetColor();
                    Console.ReadLine();
                }
                else
                {
                    RecipeClassObjectHere.ErrorPrint("\r\n     Cancelled");
                    Console.ReadLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //-----------------------------------------------------------------------------------------------//
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//