using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    internal class ConversionClass
    {
        public string[] Unit = { "Ml(s)", "Teaspoon(s)", "Tablespoon(s)", "Cups(s)", "Litre(s)", "Gram(s)", "Kilogram(s)", "Other" };

        public string SelectedUnit { get; set; } = string.Empty;

        public double SelectedVolume { get; set; } = 0;

        public double TotalVolume { get; set; } = 0;

        public double[] VolumePerUnit = { 1, 5, 15, 237, 1000, 1, 1000, 1 };

        public string MeasurementUnitHere { get; set; } = string.Empty;

        public double IngredientQuantityHere { get; set; } = 0;

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConversionClass()
        {

        }

        //-----------------------------------------------------------------------------------------------//
        public (string, double) CheckForUpdates(string measurementUnitInput, double ingredientQuantityInput)
        {            
            if (measurementUnitInput.Equals("Millilitres") || measurementUnitInput.Equals("Millilitre")
                || measurementUnitInput.Equals("Grams") || measurementUnitInput.Equals("Gram"))
            {
                ConvertQuantitiesUpwards(measurementUnitInput, ingredientQuantityInput);
            }

            if (measurementUnitInput.Equals("Litres") || measurementUnitInput.Equals("Litre")
                || measurementUnitInput.Equals("Grams") || measurementUnitInput.Equals("Gram"))
            {
                ConvertQuantitiesDownwards(measurementUnitInput, ingredientQuantityInput);
            }
            return (this.MeasurementUnitHere, this.IngredientQuantityHere);
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="measurementUnitInput"></param>
        /// <param name="ingredientQuantityInput"></param>
        public void ConvertQuantitiesUpwards(string measurementUnitInput, double ingredientQuantityInput)
        {
            double output = 0;            

            if (measurementUnitInput.Equals("Millilitres") || measurementUnitInput.Equals("Millilitre"))
            {
                if (ingredientQuantityInput >= 1000)
                {
                    output = ingredientQuantityInput / 1000;
                    this.MeasurementUnitHere = (output == 1) ? "Litre" : "Litres";
                    this.IngredientQuantityHere = output;
                }
            }
            else if (measurementUnitInput.Equals("Grams") || measurementUnitInput.Equals("Gram"))
            {
                if (ingredientQuantityInput >= 1000)
                {
                    output = ingredientQuantityInput / 1000;
                    this.MeasurementUnitHere = (output == 1) ? "Kilogram" : "Kilograms";
                    this.IngredientQuantityHere = output;
                }
            }
        }


        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// 
        /// </summary>
        /// <param name="measurementUnitInput"></param>
        /// <param name="ingredientQuantityInput"></param>
        public void ConvertQuantitiesDownwards(string measurementUnitInput, double ingredientQuantityInput)
        {
            double output = 0;
            this.MeasurementUnitHere = measurementUnitInput;

            if (measurementUnitInput.Equals("Litres") || measurementUnitInput.Equals("Litre"))
            {
                if (ingredientQuantityInput < 1)
                {
                    output = ingredientQuantityInput * 1000;
                    this.MeasurementUnitHere = (output == 1) ? "Millilitre" : "Millilitres";
                    this.IngredientQuantityHere = output;
                }
            }
            else if (measurementUnitInput.Equals("Kilograms") || measurementUnitInput.Equals("Kilogram"))
            {
                if (ingredientQuantityInput < 1)
                {
                    output = ingredientQuantityInput * 1000;
                    this.MeasurementUnitHere = (output == 1) ? "Gram" : "Grams";
                    this.IngredientQuantityHere = output;
                }
            }
        }
    }
}       
//------------------------------------------oo00 End of File 00oo-------------------------------------------//