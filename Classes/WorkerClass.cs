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
        public void MainMenu()
        {
            //Format Menu
            RecipeClassObjectHere.Format();

            //Try-catch to handle errors
            try
            {
                //Switch statement input
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
                        AddRecipe();
                        break;
                    case 2:
                        SearchRecipe();
                        break;
                    case 3:
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
        private void AddRecipe()
        {
            RecipeClass recipe = new RecipeClass();

            Console.Write("Enter recipe name: ");
            recipe.RecipeName = Console.ReadLine();

            //Ingredient Input
            int numberOfIngredients = RecipeClassObjectHere.GetPositiveIntegerInput("Enter number of ingredients: ");

            for (int i = 0; i < numberOfIngredients; i++)
            {
                recipe.GetRecipeIngredientInput();
            }


            //Step Input
            int numberOfSteps = RecipeClassObjectHere.GetPositiveIntegerInput("Enter number of steps: ");

            for (int i = 0; i < numberOfSteps; i++)
            {
                recipe.GetRecipeStepInput();
            }

            RecipeList.Add(recipe);
            Console.WriteLine("Recipe added successfully");

        }

        //-----------------------------------------------------------------------------------------------//
        
        //Search Recipes
        
        //-----------------------------------------------------------------------------------------------//
        private void SearchRecipe()
        {
            if (RecipeList.Count == 0)
            {
                Console.WriteLine("No Recipes Found.");
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
            RecipeClassObjectHere.ErrorPrint("Are you sure you want to clear this recipe. Warning, this recipe will be permanently deleted!");

            //Switch statement input that prevents incorrect inputs
            int confirm = RecipeClassObjectHere.GetPositiveIntegerInput("Enter 1 to continue");

            //If statement that checks that the choice was confirmed, then resets the recipe
            if (confirm == 1)
            {
                RecipeList.Remove(recipe);

                // Set the console foreground color to green then reset it after displaying a string
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\n       Successfully Deleted");
                Console.ResetColor();
                Console.ReadLine();
            }
            else
            {
                RecipeClassObjectHere.ErrorPrint("\r\n       Cancelled");
                Console.ReadLine();
            }
        }

        //-----------------------------------------------------------------------------------------------//
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//