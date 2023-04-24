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
            Console.WriteLine("Plesa");
            Console.ReadLine();
            recipe.GetRecipeInput();

        }
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//