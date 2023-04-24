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
        public string IngredientName { get; set; } = string.Empty;

        public string IngredientQuantity { get; set; } = string.Empty;

        public string MeasurementUnit { get; set; } = string.Empty;
//-----------------------------------------------------------------------------------------------//
/// <summary>
/// Default constructor
/// </summary>
        public IngredientClass() 
        { 
        
        }

//-----------------------------------------------------------------------------------------------//
        public void IngredientInput()
        {
            Console.WriteLine("Please enter the name of the ingredient: ");
            this.IngredientName = Console.ReadLine();

            Console.WriteLine("Please enter the quantity of the ingredient: ");
            this.IngredientQuantity = Console.ReadLine();

            Console.WriteLine("Please enter the measurement unit of the ingredient: ");
            this.MeasurementUnit = Console.ReadLine();
        }



    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//