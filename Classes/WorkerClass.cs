using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    internal class WorkerClass
    {
        /// <summary>
        /// Local Recipe Class Object
        /// </summary>
        public RecipeClass RecipeClassObjectHere = new RecipeClass();

        //------- Part 2 Code -------
        //public string name { get; set; } = string.Empty;

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

            //------- Part 2 Code -------
            //CopyObject(RecipeClassObjectHere);
        }

        //------- Part 2 Code -------
        /*public RecipeClass CopyObject(RecipeClass recipeIn)
        {
            var newRecipe = new RecipeClass();
            newRecipe.name = recipeIn.name;
            return newRecipe;
        }*/

    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//