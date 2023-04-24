﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    internal class RecipeClass
    {
        IngredientClass[] IngredientArray;

        StepClass[] StepArray;


        public IngredientClass IngredientClassHere = new IngredientClass();


        public string RecipeName { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public int NumberOfIngredients { get; set; }
        public RecipeClass()
        {

        }

        public void GetRecipeInput()
        {
            this.IngredientClassHere.IngredientInput();

            Console.WriteLine("Enter Recipe Name:");
            RecipeName = Console.ReadLine();
            Console.WriteLine("Enter Number of Ingredients:");
            NumberOfIngredients = IntErrorHandling(Console.ReadLine());
            IngredientArray = new IngredientClass[NumberOfIngredients];
                        
            for (int i = 0; i < this.NumberOfIngredients; i++)
            {
                var ingredients = new IngredientClass();
                //IngredientClassHere.GetIngredientDetails();            
                ingredients.IngredientName = this.IngredientClassHere.IngredientName;
                //ingredients.IngredientName = this.IngredientClassHere.IngredientName;
                //ingredients.IngredientName = this.IngredientClassHere.IngredientName;
                IngredientArray[i] = ingredients;
            }
            Console.WriteLine(IngredientArray[0].IngredientName);
            Console.ReadLine();

        }

        public int IntErrorHandling(string input)
        {
            try
            {

            }
            catch (Exception ex) { }
            return 0;
        }


        public RecipeClass CopyObject(RecipeClass recipeIn)
        {
            var newRecipe = new RecipeClass();

            newRecipe.name = recipeIn.name;

            return newRecipe;
        }


    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//