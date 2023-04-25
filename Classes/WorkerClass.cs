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

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public WorkerClass()
        {

        }

        public void RunWorker()
        {
            RecipeClassObjectHere.RunRecipe();
        }
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//