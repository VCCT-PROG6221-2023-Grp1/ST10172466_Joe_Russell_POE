using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PROG6221_POE_Part_1.Classes
{
    internal class WorkerClass
    {
        /// <summary>
        /// Local Recipe Class Object
        /// </summary>
        public RecipeClass RecipeClassObjectHere = new RecipeClass();

        List<RecipeClass> RecipeList = new List<RecipeClass>();

        //------- Part 2 Code -------
        /*public string name { get; set; } = string.Empty;
        
        1. The user shall be able to enter an unlimited number of recipes.
        2. The user shall be able to enter a name for each recipe. 
        3. The software shall display a list of all the recipes to the user in alphabetical order by name. 
        4. The user can choose which recipe to display from the list.
        5. For each ingredient, the user shall additionally be able to enter:
            a.The number of calories, and
            b. The food group that the ingredient belongs to. 
        6. The software shall calculate and display the total calories of all the ingredients in a recipe. 
        7. The software shall notify the user when the total calories of a recipe exceed 300. 

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
            RecipeClassObjectHere.RunRecipe();
            Console.WriteLine(RecipeClassObjectHere.RecipeName);
            //------- Part 2 Code -------
            //CopyObject(RecipeClassObjectHere);
        }

        //------- Part 2 Code -------
        //Method that does something, use if you can figure it out
        public RecipeClass CopyObject(RecipeClass recipeIn)
        {
            var newRecipe = new RecipeClass();
            newRecipe.RecipeName = recipeIn.RecipeName;
            return newRecipe;
        }

        public void RecipeSearch()
        {

        }

        /*public void RecipeDisplay()
        {
            RecipeList.Sort(RecipeList.Contains(RecipeClassObjectHere));
        }*/
    }
}


//------------------------------------------oo00 End of File 00oo-------------------------------------------//