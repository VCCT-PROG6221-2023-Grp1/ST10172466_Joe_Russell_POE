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
        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConversionClass()
        {

        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to check for any changes in the values that it is passed
        /// </summary>
        /// <param name="measurementUnitInput"></param>
        /// <param name="ingredientQuantityInput"></param>
        /// <returns></returns>
        public (string, double) CheckForUpdates(string measurementUnitInput, double ingredientQuantityInput)
        {
            if (measurementUnitInput.Equals("Millilitres") || measurementUnitInput.Equals("Millilitre")
                || measurementUnitInput.Equals("Grams") || measurementUnitInput.Equals("Gram"))
            {
                return ConvertQuantitiesUpwards(measurementUnitInput, ingredientQuantityInput);
            }

            if (measurementUnitInput.Equals("Litres") || measurementUnitInput.Equals("Litre")
                || measurementUnitInput.Equals("Kilograms") || measurementUnitInput.Equals("Kilogram"))
            {
                return ConvertQuantitiesDownwards(measurementUnitInput, ingredientQuantityInput);
            }

            // If no updates needed, return the original values
            return (measurementUnitInput, ingredientQuantityInput);
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to convert values from millilitres and grams to litres and kilograms
        /// </summary>
        /// <param name="measurementUnitInput"></param>
        /// <param name="ingredientQuantityInput"></param>
        /// <returns></returns>
        public (string, double) ConvertQuantitiesUpwards(string measurementUnitInput, double ingredientQuantityInput)
        {
            double output = 0;

            if (measurementUnitInput.Equals("Millilitres") || measurementUnitInput.Equals("Millilitre"))
            {
                if (ingredientQuantityInput >= 1000)
                {
                    output = ingredientQuantityInput / 1000;
                    string newMeasurementUnit = (output == 1) ? "Litre" : "Litres";
                    return (newMeasurementUnit, output);
                }
                else
                {
                    output = ingredientQuantityInput;
                    string newMeasurementUnit = (output == 1) ? "Millilitre" : "Millilitres";
                    return (newMeasurementUnit, output);
                }
            }
            else if (measurementUnitInput.Equals("Grams") || measurementUnitInput.Equals("Gram"))
            {
                if (ingredientQuantityInput >= 1000)
                {
                    output = ingredientQuantityInput / 1000;
                    string newMeasurementUnit = (output == 1) ? "Kilogram" : "Kilograms";
                    return (newMeasurementUnit, output);
                }
                else
                {
                    output = ingredientQuantityInput;
                    string newMeasurementUnit = (output == 1) ? "Gram" : "Grams";
                    return (newMeasurementUnit, output);
                }
            }
            // If no conversion needed, return the original values
            return (measurementUnitInput, ingredientQuantityInput);
        }

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Method to convert values from litres and kilograms to millilitres and grams
        /// </summary>
        /// <param name="measurementUnitInput"></param>
        /// <param name="ingredientQuantityInput"></param>
        /// <returns></returns>
        public (string, double) ConvertQuantitiesDownwards(string measurementUnitInput, double ingredientQuantityInput)
        {
            double output = 0;

            if (measurementUnitInput.Equals("Litres") || measurementUnitInput.Equals("Litre"))
            {
                if (ingredientQuantityInput < 1)
                {
                    output = ingredientQuantityInput * 1000;
                    string newMeasurementUnit = (output == 1) ? "Millilitre" : "Millilitres";
                    return (newMeasurementUnit, output);
                }
                else
                {
                    output = ingredientQuantityInput;
                    string newMeasurementUnit = (output == 1) ? "Litre" : "Litres";
                    return (newMeasurementUnit, output);
                }
            }
            else if (measurementUnitInput.Equals("Kilograms") || measurementUnitInput.Equals("Kilogram"))
            {
                if (ingredientQuantityInput < 1)
                {
                    output = ingredientQuantityInput * 1000;
                    string newMeasurementUnit = (output == 1) ? "Gram" : "Grams";
                    return (newMeasurementUnit, output);
                }
                else
                {
                    output = ingredientQuantityInput;
                    string newMeasurementUnit = (output == 1) ? "Kilogram" : "Kilograms";
                    return (newMeasurementUnit, output);
                }
            }

            // If no conversion needed, return the original values
            return (measurementUnitInput, ingredientQuantityInput);
        }
        //-----------------------------------------------------------------------------------------------//
    }
}    
//------------------------------------------oo00 End of File 00oo-------------------------------------------//