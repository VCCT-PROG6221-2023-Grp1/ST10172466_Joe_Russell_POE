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
    internal class WorkerClass
    {
        /// <summary>
        /// Local Recipe Class Object
        /// </summary>
        public RecipeClass RecipeClassObjectHere = new RecipeClass();

        /// <summary>
        /// Recipe Class List
        /// </summary>
        public List<RecipeClass> RecipeList = new List<RecipeClass>();


        /*------- Part 2 Code -------        
        Issues:
            - None Currently
             

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
                        AddRecipe();
                        break;
                    case 2:
                        //Calling method to search for existing recipes
                        SearchRecipe();
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

        //AddCalories Recipe to List

        //-----------------------------------------------------------------------------------------------//
        private void AddRecipe()
        {
            //Creating recipe class instance
            RecipeClass recipe = new RecipeClass();

            try
            {
                //Assigns value to Recipe Name by calling input method
                recipe.RecipeName = RecipeClassObjectHere.RecipeNameInputMethod("\r\nEnter the Recipe Name: ");

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
        private void SearchRecipe()
        {
            if (RecipeList.Count == 0)
            {
                RecipeClassObjectHere.ErrorPrint("\r\n     No Recipes Found");
                Console.ReadLine();
                return;
            }

            //Print list of recipe names
            Console.WriteLine("===== Recipes =====");
            foreach (var recipe in RecipeList.OrderBy(r => r.RecipeName))
            {
                Console.WriteLine(recipe.RecipeName);
            }
            Console.WriteLine("===================");

            //Search Input
            Console.Write("Enter the name of the recipe you want to select: ");
            string recipeName = Console.ReadLine();

            //Search
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
                Console.WriteLine("Recipe not found.");
            }

            Console.Clear();            
        }

        //-----------------------------------------------------------------------------------------------//

        //Show Search Recipe Menu

        //-----------------------------------------------------------------------------------------------//
        private void RecipeMenu(RecipeClass recipe)
        {
            //Format Menu
            RecipeClassObjectHere.Format();

            //Switch statement input
            int option = RecipeClassObjectHere.GetPositiveIntegerInput("     Enter 1 to Scale Recipe Quantity Values" +
                "\n     Enter 2 to Reset Quantity Values" +
                "\n     Enter 3 to View Recipe" +
                "\n     Enter 4 to Delete Recipe" +
                "\n     Enter 5 to Return to Main Menu");

            switch (option)
            {
                case 1:
                    //Scales quantity values
                    recipe.ScaleRecipe();
                    break;
                case 2:
                    //Resets quantity values to original
                    recipe.ResetQuantity();
                    break;
                case 3:
                    //Displays Recipe
                    recipe.DisplayRecipe();
                    break;
                case 4:
                    //Deletes Recipe
                    DeleteRecipe(recipe);
                    return;
                case 5:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
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

        //-----------------------------------------------------------------------------------------------//
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//