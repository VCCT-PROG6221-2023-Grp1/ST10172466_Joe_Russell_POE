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
        1. The user shall be able to enter an unlimited number of RecipeList.
        2. The user shall be able to enter a name for each recipe. 
        3. The software shall display a list of all the RecipeList to the user in alphabetical order by name. 
        4. The user can choose which recipe to display from the list.


        Issues:
            - Recipe Name being overwritten by subsequent entries
            - All recipe details displayed at once
             

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
        /*
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
                    break;
                case 2:
                    DisplayAttribute(RecipeList, "da");
                    //this.Display(this.RecipeSearch());

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

            //Clear console for tidiness
            Console.Clear();
            this.MenuDisplay();
        }

        static void DisplayAttribute(List<RecipeClass> recipeList, string attributeName)
        {
            foreach (RecipeClass recipe in recipeList)
            {
                Type type = recipe.GetType();
                PropertyInfo propertyInfo = type.GetProperty(attributeName);
                if (propertyInfo != null)
                {
                    object attributeValue = propertyInfo.GetValue(recipe);
                    Console.WriteLine(attributeValue);
                }
                else
                {
                    Console.WriteLine("Ah");
                    Console.ReadLine();
                }
            }
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to get Recipe Inputs
        /// </summary>
        public void RecipeInput()
        {
            var recipe = new RecipeClass();

            RecipeClassObjectHere.RecipeInput();

            recipe.RecipeName = this.RecipeClassObjectHere.RecipeName;
            recipe.IngredientList = this.RecipeClassObjectHere.IngredientList;
            recipe.StepList = this.RecipeClassObjectHere.StepList;

            //Assigning values to Recipe List
            this.RecipeList.Add(recipe);
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
                recipe.ErrorPrint("\r\nWarning!!! Excessive Calories detected!\r\n" +
                    "\r\nCalories are the unit used to determine the amount of energy in food or drinks.\r\n" +
                    "Excessive calorie consumption can lead to increased weight gain, which comes with a lot of risks.\r\n" +
                    "Extra calories places your heart at risk.\r\n" +
                    "It can lead to atherosclerosis. " +
                    "Which causes the stiffening of the artery wall, \r\nthis increases the risk of having a heart attack or stroke.\r\n" +
                    "\r\nBeing overweight heightens the risk for fatty liver disease, certain cancers and high blood pressure.\r\n" +
                    "It also increases the pressure on your joints, raising the risk of osteoarthritis.\r\n" +
                    "The extra fat surrounding your neck can cause breathing problems and lead to sleep apnea, \r\n" +
                    "a condition in which you stop breathing temporarily while asleep.");
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
        */











        /*
        public void MenuDisplay()
        {            
            int option = GetPositiveIntegerInput("Enter 1 to add a recipe, 2 to display recipe list, or 3 to exit:");
            switch (option)
            {
                case 1:
                    RecipeClass recipe = new RecipeClass();
                    recipe.RecipeInput();
                    RecipeList.Add(recipe);
                    Console.WriteLine("Recipe added successfully.");
                    MenuDisplay();
                    break;
                case 2:
                    DisplayRecipeList();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option selected.");
                    Console.ReadLine();
                    break;
            }
        }

        public void DisplayRecipeList()
        {
            if (RecipeList.Count == 0)
            {
                Console.WriteLine("No RecipeList found.");
                return;
            }

            Console.WriteLine("Recipe List:");
            RecipeList = RecipeList.OrderBy(recipe => recipe.RecipeName, StringComparer.OrdinalIgnoreCase).ToList();
            foreach (RecipeClass recipe in RecipeList)
            {
                Console.WriteLine(recipe.RecipeName);
            }

            string recipeName = Console.ReadLine();
            RecipeClass selectedRecipe = RecipeList.Find(recipe => recipe.RecipeName.Equals(recipeName, StringComparison.OrdinalIgnoreCase));

            if (selectedRecipe != null)
            {
                Display(selectedRecipe);
                Console.WriteLine("\r\nEnter 1 to scale the recipe or 2 to clear the recipe:");
                int option = GetPositiveIntegerInput("");
                switch (option)
                {
                    case 1:
                        selectedRecipe.ScaleRecipe();
                        Console.WriteLine("Recipe scaled successfully.");
                        break;
                    case 2:
                        selectedRecipe.ClearRecipe();
                        Console.WriteLine("Recipe cleared successfully.");
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid option selected.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }

            // Clear console for tidiness
            Console.Clear();
            this.MenuDisplay();
        }

        public void Display(RecipeClass recipe)
        {
            Console.WriteLine("Recipe Details:");
            Console.WriteLine("Name: " + recipe.RecipeName);

            // Display ingredient details

            Console.WriteLine("Ingredients:");
            foreach (IngredientClass ingredient in recipe.IngredientList)
            {
                Console.WriteLine("- " + ingredient.IngredientName);
            }

            // Display step details

            Console.WriteLine("Steps:");
            for (int i = 0; i < recipe.StepList.Count; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ": " + recipe.StepList[i].StepDescription);
            }

            Console.ReadLine();
        }

        public int GetPositiveIntegerInput(string message)
        {
            int input;
            bool isValid;
            do
            {
                Console.WriteLine(message);
                isValid = int.TryParse(Console.ReadLine(), out input) && input > 0;
                if (!isValid)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            } while (!isValid);
            return input;
        }
    }
}*/

        //-----------------------------------------------------------------------------------------------//
        public void MainMenu()
        {
            //Format Menu
            RecipeClassObjectHere.Format();

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