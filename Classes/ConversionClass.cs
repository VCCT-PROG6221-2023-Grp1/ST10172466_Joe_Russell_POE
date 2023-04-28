using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
    internal class ConversionClass
    {
        public string MeasurementUnitHere { get; set; } = string.Empty;

        public double IngredientQuantityHere { get; set; } = 0;

        //-----------------------------------------------------------------------------------------------//
        public ConversionClass() { }
        //-----------------------------------------------------------------------------------------------//
        public void ConvertQuantitiesUpwards(string MeasurementUnitInput, double IngredientQuantityInput)
        {
            this.MeasurementUnitHere = MeasurementUnitInput;

            if (MeasurementUnitInput.Equals("Millilitres"))
            {
                this.ConvertMillilitresToLitres(IngredientQuantityInput);
            }

            else if (MeasurementUnitInput.Equals("Grams"))
            {
                this.ConvertGramsToKilograms(IngredientQuantityInput);
            }
        }

        public void ConvertQuantitiesDownwards(string MeasurementUnitInput, double IngredientQuantityInput)
        {
            this.MeasurementUnitHere = MeasurementUnitInput;

            if (MeasurementUnitInput.Equals("Millilitres"))
            {
                this.ConvertLitresToMillilitres(IngredientQuantityInput);
            }

            else if (MeasurementUnitInput.Equals("Grams"))
            {
                this.ConvertKilogramsToGrams(IngredientQuantityInput);
            }
        }

        //-----------------------------------------------------------------------------------------------//
        public void ConvertMillilitresToLitres(double millilitres)
        {
            double litres = 0;

            if (millilitres >= 1000)
            {
                litres = millilitres / 1000;
                if (litres == 1)
                {
                    this.MeasurementUnitHere = "Litre";
                    this.IngredientQuantityHere = litres;
                }
                else
                {
                    this.MeasurementUnitHere = "Litres";
                    this.IngredientQuantityHere = litres;
                }
            }
        }


        //-----------------------------------------------------------------------------------------------//
        public void ConvertGramsToKilograms(double grams)
        {
            double kilograms = 0;

            if (grams >= 1000)
            {
                kilograms = grams / 1000;
                if (kilograms == 1)
                {
                    this.MeasurementUnitHere = "Kilogram";
                    this.IngredientQuantityHere = kilograms;
                }
                else
                {
                    this.MeasurementUnitHere = "Kilograms";
                    this.IngredientQuantityHere = kilograms;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------//
        //-----------------------------------------------------------------------------------------------//
        public void ConvertLitresToMillilitres(double litres)
        {
            double millilitres = 0;

            if (litres <= 1)
            {
                millilitres = litres * 1000;
                if (millilitres == 1)
                {
                    this.MeasurementUnitHere = "Milliitre";
                    this.IngredientQuantityHere = millilitres;
                }
                else
                {
                    this.MeasurementUnitHere = "Millilitres";
                    this.IngredientQuantityHere = millilitres;
                }
            }
        }


        //-----------------------------------------------------------------------------------------------//
        public void ConvertKilogramsToGrams(double kilograms)
        {
            double grams = 0;

            if (kilograms <= 1)
            {
                grams = kilograms * 1000;
                if (grams == 1)
                {
                    this.MeasurementUnitHere = "Gram";
                    this.IngredientQuantityHere = grams;
                }
                else
                {
                    this.MeasurementUnitHere = "Grams";
                    this.IngredientQuantityHere = grams;
                }
            }
        }
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//