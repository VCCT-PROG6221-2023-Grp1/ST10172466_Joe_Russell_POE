using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    internal class IngredientClass
    {
        public string IngredientName { get; set; } = String.Empty;

        public IngredientClass() 
        { 
        
        }

        public void IngredientInput()
        {
            this.IngredientName = "Egg";
        }

        public void GetIngredientName()
        {

        }



    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//