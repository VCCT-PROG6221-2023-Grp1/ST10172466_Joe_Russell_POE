using System;
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

        public StepClass StepClassHere = new StepClass();


        public string RecipeName { get; set; } = string.Empty;

        public string name { get; set; } = string.Empty;

        public int NumberOfIngredients { get; set; } = 0;

        public int NumberOfSteps { get; set; } = 0;

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default constructor
        /// </summary>
        public RecipeClass()
        {

        }

        //-----------------------------------------------------------------------------------------------//
        public void RunRecipe()
        {
            this.Format();
            Console.WriteLine("Enter 1 to enter Recipe Details" +
                "\nEnter 2 to Scale Recipe Quantity Values" +
                "\nEnter 3 to Reset Quantity Values" +
                "\nEnter 4 to View Recipe" +
                "\nEnter 5 to Exit");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    this.GetRecipeInput();
                    this.GetRecipeStepInput();
                    break;
                case 2:
                    this.ScaleRecipe();
                    break;
                case 3:
                    this.CopyObject(new RecipeClass());
                    break;
                case 4:
                    this.DisplayRecipe();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }
            Console.Clear();
            this.RunRecipe();

        }


        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to get the Ingredient Inputs
        /// </summary>
        public void GetRecipeInput()
        {
            Console.WriteLine("\r\nEnter Recipe Name:");
            RecipeName = Console.ReadLine();
            Console.WriteLine("\r\nEnter Number of Ingredients:");
            NumberOfIngredients = IntErrorHandling(Console.ReadLine());
            IngredientArray = new IngredientClass[NumberOfIngredients];

            for (int i = 0; i < this.NumberOfIngredients; i++)
            {
                var ingredients = new IngredientClass();
                IngredientClassHere.IngredientInput();
                ingredients.IngredientName = this.IngredientClassHere.IngredientName;
                ingredients.IngredientQuantity = this.IngredientClassHere.IngredientQuantity;
                ingredients.MeasurementUnit = this.IngredientClassHere.MeasurementUnit;
                IngredientArray[i] = ingredients;
            }
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to get the Step Inputs
        /// </summary>
        public void GetRecipeStepInput()
        {
            Console.WriteLine("Enter Number of Steps: ");
            this.NumberOfSteps = int.Parse(Console.ReadLine());

            /*
            Implement with error handling

            this.NumberOfSteps = int.Parse(StepNumInput());
             */

            StepArray = new StepClass[this.NumberOfSteps];

            for (int i = 0; i < this.NumberOfSteps; i++)
            {
                var steps = new StepClass();
                StepClassHere.StepInput();
                steps.StepDescription = this.StepClassHere.StepDescription;
                StepArray[i] = steps;
            }
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Display Recipe Ingredients and Steps
        /// </summary>
        public void DisplayRecipe()
        {
            string ingDisplay = "";
            Console.WriteLine("This recipe requires:");
            for (int i = 0; i < this.NumberOfIngredients; i++)
            {
                ingDisplay += "- " + IngredientArray[i].IngredientQuantity.ToString() + 
                    " " + IngredientArray[i].MeasurementUnit + 
                    " of " + IngredientArray[i].IngredientName + "\r\n";

            }
            Console.WriteLine(ingDisplay);

            string stepDisplay = "";
            Console.WriteLine("\r\nFollow these steps:");
            for (int i = 0; i < this.NumberOfSteps; i++)
            {
                stepDisplay += "Step " + (i+1) + ": \r\n" +
                    StepArray[i].StepDescription + "\r\n\r\n";
            }
            Console.WriteLine(stepDisplay);


            Console.ReadLine();
        }

        //-----------------------------------------------------------------------------------------------//
        public void ScaleRecipe()
        {
            Console.WriteLine("\r\nEnter 1 for half, 2 for double or 3 for triple");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    for (int i = 0; i < this.NumberOfIngredients; i++)
                    {
                        IngredientArray[i].IngredientQuantity = IngredientArray[i].IngredientQuantity * 0.5;
                    }
                    break;
                case 2:
                    for (int i = 0; i < this.NumberOfIngredients; i++)
                    {
                        IngredientArray[i].IngredientQuantity = IngredientArray[i].IngredientQuantity * 2;
                    }
                    break;
                case 3:
                    for (int i = 0; i < this.NumberOfIngredients; i++)
                    {
                        IngredientArray[i].IngredientQuantity = IngredientArray[i].IngredientQuantity * 3;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid option selected.");
                    break;
            }

        }

        //-----------------------------------------------------------------------------------------------//
        public int IntErrorHandling(string input)
        {
            int ingNum = 0;
            try
            {
                bool isOnlyDigits = !string.IsNullOrEmpty(input) && input.All(char.IsDigit);

                if (isOnlyDigits)
                {
                    ingNum = int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Please only enter digits\r\n");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return ingNum;
        }

        /*public string StepNumInput()
        {
            Console.WriteLine("Please enter the number of steps: ");
            string input = Console.ReadLine();
            string result = "";

            bool containsOnlyDigits = true;

            try
            {
                foreach (char c in input)
                {
                    if (!char.IsDigit(c))
                    {
                        containsOnlyDigits = false;
                        break;
                    }
                }

                if (containsOnlyDigits)
                {
                    Console.WriteLine("The input string contains only digits.");
                    result = input;
                }
                else
                {
                    Console.WriteLine("The input string contains non-digit characters.");
                    this.StepNumInput();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }*/
        //-----------------------------------------------------------------------------------------------//
        public RecipeClass CopyObject(RecipeClass recipeIn)
        {
            var newRecipe = new RecipeClass();

            newRecipe.name = recipeIn.name;

            return newRecipe;
        }

        //-----------------------------------------------------------------------------------------------//
        public void Format()
        {

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(@" (                          (                                      
");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(@" )\ )                       )\ )                                                
");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(@"(()/(  (    (          (   (()/((        (  ( (      )    )    
 /(_))))\ ( )\ `  )   ))\   /(_))(   (   )\))()(  ( /(   (                       
");

            // Set the console foreground color to yellow
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(@"(_)) /((_))((_)/(/(  /((_) (_))(()\  )\ ((_))(()\ )(_))  )\  ' 
| _ (_)) ((_|_|(_)_\(_))   | _ \((_)((_) (()(_|(_|(_)_ _((_))  
|   / -_) _|| | '_ \) -_)  |  _/ '_/ _ \/ _` | '_/ _` | '  \() 
");

            // Reset the console foreground color
            Console.ResetColor();

            // Display the ASCII art
            Console.Write(@"|_|_\___\__||_| .__/\___|  |_| |_| \___/\__, |_| \__,_|_|_|_|  
              |_|                       |___/
");

            Console.WriteLine("___________________________________________________________________________________________________________________\r\n");
        }

    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//