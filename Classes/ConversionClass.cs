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
        public void ConvertQuantities(string MeasurementUnitInput, double IngredientQuantityInput)
        {
            this.MeasurementUnitHere = MeasurementUnitInput;

            if (MeasurementUnitInput.Equals("Teaspoons"))
            {
                this.ConvertTeaspoonsToCups(IngredientQuantityInput);
            }
            else if (MeasurementUnitInput.Equals("Fluid Ounces"))
            {
                this.ConvertFluidOuncesToQuarts(IngredientQuantityInput);
            }
            else if (MeasurementUnitInput.Equals("Grams"))
            {
                this.ConvertGramsToKilograms(IngredientQuantityInput);
            }
        }        

        //-----------------------------------------------------------------------------------------------//
        public double ConvertTeaspoonsToCups(double teaspoons)
        {
            const double TEASPOONS_PER_TABLESPOON = 3.0;
            const double TABLESPOONS_PER_CUP = 16.0;

            double tablespoons = 0.0;
            double cups = 0.0;

            if (teaspoons >= TEASPOONS_PER_TABLESPOON)
            {
                tablespoons = teaspoons / TEASPOONS_PER_TABLESPOON;
                teaspoons %= TEASPOONS_PER_TABLESPOON;

                if (tablespoons == 1)
                {
                    this.MeasurementUnitHere = "Tablespoon";
                    this.IngredientQuantityHere = tablespoons;

                }
                this.MeasurementUnitHere = "Tablespoons";
                this.IngredientQuantityHere = tablespoons;
            }

            if (tablespoons >= TABLESPOONS_PER_CUP)
            {
                cups = tablespoons / TABLESPOONS_PER_CUP;
                tablespoons %= TABLESPOONS_PER_CUP;

                if (cups == 1)
                {
                    this.MeasurementUnitHere = "Cup";
                    this.IngredientQuantityHere = cups;
                }
                this.MeasurementUnitHere = "Cups";
                this.IngredientQuantityHere = cups;
            }

            return cups;
        }

//-----------------------------------------------------------------------------------------------//
        public double ConvertFluidOuncesToQuarts(double fluidOunces)
        {
            const double FLUID_OUNCES_PER_CUP = 8.0;
            const double CUPS_PER_PINT = 2.0;
            const double PINTS_PER_QUART = 2.0;

            double cups = 0.0;
            double pints = 0.0;
            double quarts = 0.0;

            if (fluidOunces >= FLUID_OUNCES_PER_CUP)
            {
                cups = fluidOunces / FLUID_OUNCES_PER_CUP;
                fluidOunces %= FLUID_OUNCES_PER_CUP;

                if (cups == 1)
                {
                    this.MeasurementUnitHere = "Cup";
                    this.IngredientQuantityHere = cups;
                }
                this.MeasurementUnitHere = "Cups";
                this.IngredientQuantityHere = cups;
            }

            if (cups >= CUPS_PER_PINT)
            {
                pints = cups / CUPS_PER_PINT;
                cups %= CUPS_PER_PINT;

                if (pints == 1)
                {
                    this.MeasurementUnitHere = "Pint";
                    this.IngredientQuantityHere = pints;
                }
                this.MeasurementUnitHere = "Pints";
                this.IngredientQuantityHere = pints;
            }

            if (pints >= PINTS_PER_QUART)
            {
                quarts = pints / PINTS_PER_QUART;
                pints %= PINTS_PER_QUART;

                if (quarts == 1)
                {
                    this.MeasurementUnitHere = "Quart";
                    this.IngredientQuantityHere = quarts;
                }
                this.MeasurementUnitHere = "Quarts";
                this.IngredientQuantityHere = quarts;
            }

            return quarts;
        }

        //-----------------------------------------------------------------------------------------------//
        public double ConvertGramsToKilograms(double grams)
        {
            const double GRAMS_PER_KILOGRAM = 1000.0;

            double kilograms = 0.0;


            if (grams >= GRAMS_PER_KILOGRAM)
            {
                kilograms = grams / GRAMS_PER_KILOGRAM;
                grams %= GRAMS_PER_KILOGRAM;

                if (kilograms == 1)
                {
                    this.MeasurementUnitHere = "Kilogram";
                    this.IngredientQuantityHere = kilograms;
                }
                this.MeasurementUnitHere = "Kilograms";
                this.IngredientQuantityHere = kilograms;
            }

            return kilograms;
        }

        //-----------------------------------------------------------------------------------------------//
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//