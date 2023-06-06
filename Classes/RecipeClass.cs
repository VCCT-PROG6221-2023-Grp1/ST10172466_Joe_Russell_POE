using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    public delegate void SerialData(double dataOut);

    public class RecipeClass
    {
        //Create A listener
        public event SerialData SerialDataSend;

        /// <summary>
        /// Virtual means it can be overriden and derrived by any class - Access Modifier
        /// This method will invoke the delegate and link the methods
        /// </summary>
        /// <param name="dataOut"></param>
        public virtual void OnDataSend(double dataOut)
        {
            SerialDataSend?.Invoke(dataOut);
        }

        /// <summary>
        /// Ingredient Class List
        /// </summary>
        private List<IngredientClass> IngredientList = new List<IngredientClass>();

        /// <summary>
        /// Step Class List
        /// </summary>
        //StepClass[] StepArray;
        private List<StepClass> StepList = new List<StepClass>();

        /// <summary>
        /// Local Ingredient Class Object
        /// </summary>
        private IngredientClass IngredientClassObjectHere = new IngredientClass();

        /// <summary>
        /// Local Step Class Object
        /// </summary>
        private StepClass StepClassObjectHere = new StepClass();

        /// <summary>
        /// Delegate used to calculate calories
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public delegate double Calculate(double x, double y);

        //------- Part 2 Code -------
        /// <summary>
        /// Local Conversion Class Object
        /// </summary>
        //public ConversionClass ConversionClassObjectHere = new ConversionClass();        

        /// <summary>
        /// String that holds the Recipe Name
        /// </summary>
        public string RecipeName { get; set; } = string.Empty;

        /// <summary>
        /// Int that holds the number of ingredients
        /// </summary>
        public int NumberOfIngredients { get; set; } = 0;

        /// <summary>
        /// Int that holds the number of steps
        /// </summary>
        public int NumberOfSteps { get; set; } = 0;

        /// <summary>
        /// Double that holds the ammount that ingredients are scaled by
        /// </summary>
        public double ScaleFactor { get; set; } = 0;

        /// <summary>
        /// Bool that checks whether a recipe has been scaled or not
        /// </summary>
        public bool Scaled { get; set; } = false;

        /// <summary>
        /// Bool that checks whether a recipe's scaling has been reset or not
        /// </summary>
        public bool ScaleReset { get; set; } = false;

        /// <summary>
        /// Double that holds the total amount od calories in a recipe
        /// </summary>
        public double TotalCalories { get; set; } = 0;

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default constructor
        /// </summary>
        public RecipeClass()
        {

        }

        //-----------------------------------------------------------------------------------------------//

        //Input Methods

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to get the Ingredient Inputs
        /// </summary>
        public void GetRecipeIngredientInput()
        {
            //Try-catch to handle errors
            try
            {
                //Creating delegate instance and assigning method to it
                Calculate addDelegate = new Calculate(AddCalories);

                var ingredients = new IngredientClass();

                //Calling method to input ingredient values
                IngredientClassObjectHere.IngredientInput();

                //Assigning values to Ingredient List
                ingredients.IngredientName = this.IngredientClassObjectHere.IngredientName;
                ingredients.IngredientQuantity = this.IngredientClassObjectHere.IngredientQuantity;
                ingredients.MeasurementUnit = this.IngredientClassObjectHere.MeasurementUnit;
                ingredients.CalorieAmount = this.IngredientClassObjectHere.CalorieAmount;
                ingredients.FoodGroup = this.IngredientClassObjectHere.FoodGroup;

                //Delegate that calculates total calories
                this.TotalCalories = addDelegate(this.TotalCalories, ingredients.CalorieAmount);

                //Assigning values to Ingredient List
                this.IngredientList.Add(ingredients);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //-----------------------------------------------------------------------------------------------//

        /// <summary>
        /// Method to get the Step Inputs
        /// </summary>
        public void GetRecipeStepInput()
        {
            //Try-catch to handle errors
            try
            {
                //Set the console foreground color to dark red then reset it after displaying a string
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("____________________________________________________________________");
                Console.ResetColor();

                var steps = new StepClass();

                //Calling method to input step values
                StepClassObjectHere.StepInput();

                //Assigning values to Step List
                steps.StepDescription = this.StepClassObjectHere.StepDescription;
                StepList.Add(steps);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //-----------------------------------------------------------------------------------------------//

        //Scaling Methods

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to scale the Quantities
        /// </summary>
        public void ScaleRecipe()
        {
            //If statement checks to see if recipe has been scaled before
            if (this.Scaled == true)
            {
                this.ErrorPrint("\r\nAlready Scaled");
                Console.ReadLine();
                return;
            }

            //Switch Statement input 
            int option = GetPositiveIntegerInput("\r\nEnter 1 for half, 2 for double or 3 for triple");

            //Prevents incorrect switch statement choice if input is out of bounds
            if (option > 3)
            {
                this.ErrorPrint("\r\nInvalid Input");
                Console.ReadLine();
                return;
            }

            //Try-catch to handle errors
            try
            {
                this.ScaleReset = true;

                //Save variables to different array
                switch (option)
                {
                    case 1:
                        //Halves Ingredient Quantities in array
                        foreach (IngredientClass ingredient in IngredientList)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 0.5;

                            //------- Part 2 Code -------
                            /*this.ConversionClassObjectHere.CheckForUpdates(ingredient.IngredientQuantity, 0.5);

                            ingredient.IngredientQuantity = this.ConversionClassObjectHere.SelectedVolume;

                            ingredient.MeasurementUnit = this.ConversionClassObjectHere.SelectedUnit;

                            if (ingredient.IngredientQuantity >= 1000)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesUpwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);
                            }
                            else if (ingredient.IngredientQuantity < 1)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesDownwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);
                            }
                            if (this.ConversionClassObjectHere.IngredientQuantityHere != 0)
                            {
                                ingredient.IngredientQuantity = this.ConversionClassObjectHere.IngredientQuantityHere;
                                ingredient.MeasurementUnit = this.ConversionClassObjectHere.MeasurementUnitHere;
                            }*/
                        }

                        //Sets scale factor to 0.5 for calculations
                        this.ScaleFactor = 0.5;

                        //Setting bool to true to prevent recipe from being scaled again before scale has been reset
                        this.Scaled = true;
                        break;
                    case 2:
                        //Doubles Ingredient Quantities in array
                        foreach (IngredientClass ingredient in IngredientList)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 2;

                            //------- Part 2 Code -------
                            /*if (ingredient.IngredientQuantity >= 1000)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesUpwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);
                            }
                            else if (ingredient.IngredientQuantity < 1)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesDownwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);                            
                            }

                            if (this.ConversionClassObjectHere.IngredientQuantityHere != 0)
                            {
                                ingredient.IngredientQuantity = this.ConversionClassObjectHere.IngredientQuantityHere;
                                ingredient.MeasurementUnit = this.ConversionClassObjectHere.MeasurementUnitHere;
                            }*/
                        }

                        //Sets scale factor to 2 for calculations
                        this.ScaleFactor = 2;

                        //Setting bool to true to prevent recipe from being scaled again before scale has been reset
                        this.Scaled = true;
                        break;
                    case 3:
                        foreach (IngredientClass ingredient in IngredientList)
                        {
                            ingredient.IngredientQuantity = ingredient.IngredientQuantity * 3;

                            //------- Part 2 Code -------
                            /*if (ingredient.IngredientQuantity >= 1000)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesUpwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);
                            }
                            else if (ingredient.IngredientQuantity < 1)
                            {
                                this.ConversionClassObjectHere.ConvertQuantitiesDownwards(ingredient.MeasurementUnit, ingredient.IngredientQuantity);
                            }

                            if (this.ConversionClassObjectHere.IngredientQuantityHere != 0)
                            {
                                ingredient.IngredientQuantity = this.ConversionClassObjectHere.IngredientQuantityHere;
                                ingredient.MeasurementUnit = this.ConversionClassObjectHere.MeasurementUnitHere;
                            }*/
                        }

                        //Sets scale factor to 3 for calculations
                        this.ScaleFactor = 3;

                        //Setting bool to true to prevent recipe from being scaled again before scale has been reset
                        this.Scaled = true;
                        break;
                    default:
                        this.ErrorPrint("Invalid option selected.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Reset Quantity Values
        /// </summary>
        /// <param name="recipeIn"></param>
        /// <returns></returns>
        public void ResetQuantity()
        {
            //If statement to prevent scale from being reset if it hasn't been scale before
            if (this.ScaleReset == false)
            {
                this.ErrorPrint("\r\nScale Recipe First");
                Console.ReadLine();
                return;
            }

            //Try-catch to handle errors
            try
            {
                this.Scaled = false;

                foreach (IngredientClass ingredient in IngredientList)
                {
                    //Reverses scale operation
                    ingredient.IngredientQuantity = ingredient.IngredientQuantity / this.ScaleFactor;

                    //------- Part 2 Code -------
                    /*if (this.ScaleFactor == 0.5)
                    {
                        ingredient.IngredientQuantity = ingredient.IngredientQuantity / this.ScaleFactor;
                    }
                    else if (this.ScaleFactor == 0.5)
                    {
                        ingredient.IngredientQuantity = ingredient.IngredientQuantity / this.ScaleFactor;
                    }
                    else if (this.ScaleFactor == 0.5)
                    {

                    }*/
                }

                //Set the console foreground color to green then reset it after displaying string
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\r\n     Successfully Reset");
                Console.ResetColor();
                Console.ReadLine();

                //Prevent quantity being reset before being scaled again
                this.ScaleReset = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        //-----------------------------------------------------------------------------------------------//

        //Display Recipe

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Display Recipe Ingredients and Steps
        /// </summary>
        public void DisplayRecipe()
        {
            //Set the console foreground color to green
            Console.ForegroundColor = ConsoleColor.Green;

            //Displays the ingredients
            string ingredientDisplay = "";
            Console.WriteLine("\r\nThe " + this.RecipeName + " Recipe Requires:" +
                "\r\n--------------------------------------------------------------------------------------");

            //Reset the console foreground color
            Console.ResetColor();

            //Foreach loop to display ingredients
            foreach (IngredientClass ingredient in this.IngredientList)
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
            Console.WriteLine("Total Calories: " + this.TotalCalories);

            //Prints a warning if Total Calories exceeds 300
            if (this.TotalCalories > 300)
            {
                this.ErrorPrint("\r\nWarning!!! Excessive Calories detected!\r\n" +
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

            //Int that holds the step num
            int i = 1;

            //Foreach loop to display the steps with step numbers using int i
            foreach (StepClass step in this.StepList)
            {
                stepDisplay += "Step " + (i++) + ": \r\n" +
                step.StepDescription + "\r\n\r\n";
            }

            Console.WriteLine(stepDisplay);
            Console.ReadLine();
        }

        //-----------------------------------------------------------------------------------------------//

        //Delegate Methods

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Delegate method to calculate the sum of the total calories
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public double AddCalories(double x, double y)
        {
            return x + y;
        }



        /// <summary>
        /// This method is where the information comes from
        /// </summary>
        public void DataIn(double myData)
        //public void SendData( totalCalories)
        {
            //This would be calories calculates
            if (myData > 300)
            {
                this.OnDataSend(myData);
            }

        }



        public void Test()
        {
            //Assigning the delegates
            this.SerialDataSend += DisplayCalorieWarning;

            //We are only Calling this method
            double MyDouble = 299;
            this.DataIn(MyDouble);
        }


        /// <summary>
        /// THis is where the data arrives
        /// </summary>
        /// <param name="dataOut"></param>
        private static void DisplayCalorieWarning(double dataOut)
        {
            string printData = dataOut.ToString();
            Console.WriteLine(printData);

            Console.ReadLine();
        }


        //-----------------------------------------------------------------------------------------------//

        //Error Handling Methods

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to input Recipe Name, checks that input only contains letters and spaces, with error handling
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public string RecipeNameInputMethod(string inputString)
        {
            //Holds the input
            string input = "";

            //Displays the text
            Console.WriteLine(inputString);

            //Try-catch to handle errors
            try
            {
                //While input is empty or while it contains digits or symbols, user is prompted for valid input
                while (string.IsNullOrWhiteSpace(input) || !input.Replace(" ", "").All(char.IsLetter))
                {
                    input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input) || !input.Replace(" ", "").All(char.IsLetter))
                    {
                        this.ErrorPrint("Invalid input. Please only enter letters.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return input;
        }
        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method that accepts a string and returns a positive int, with error handling
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public int GetPositiveIntegerInput(string inputString)
        {
            //Holds the input
            int number = 0;
            bool isValidInput = false;

            //Displays the text
            Console.WriteLine(inputString);

            //Try-catch to handle errors
            try
            {
                //While input is not a double or while it contains 0 or a negative number, user is prompted for valid input
                while (!isValidInput)
                {
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out number) || input.Contains("0") || !input.All(char.IsDigit))
                    {
                        this.ErrorPrint("Invalid input. Please enter a number.");
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return number;
        }

        //-----------------------------------------------------------------------------------------------//

        //Format Methods

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to Format Console Menu
        /// </summary>
        public void Format()
        {
            // Set the console foreground color to gray
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(@" (                          (                                      
");

            // Set the console foreground color to dark red
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(@" )\ )                       )\ )                                                
");
            // Set the console foreground color to dark yellow
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

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Displays message in correct format for errors
        /// </summary>
        /// <param name="input"></param>
        public void ErrorPrint(string input)
        {
            // Set the console foreground color to red
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(input);

            // Reset the console foreground color
            Console.ResetColor();
        }
        //-----------------------------------------------------------------------------------------------//
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//