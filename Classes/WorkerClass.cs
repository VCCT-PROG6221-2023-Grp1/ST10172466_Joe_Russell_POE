using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    internal class WorkerClass
    {

        public RecipeClass recipe = new RecipeClass();

        public WorkerClass()
        {

        }
        
        public void RunWorker()
        {
            recipe.RunRecipe();
           //recipe.GetRecipeInput();
            //recipe.DisplayRecipe();
           // recipe.GetRecipeStepInput();

        }
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//