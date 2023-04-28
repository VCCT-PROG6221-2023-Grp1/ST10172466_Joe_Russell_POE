using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221_POE_Part_1.Classes
{
                                    //------- Part 2 Code -------

    //-----------------------------------------------------------------------------------------------//
    internal class ConversionClass
    {
       /* public string[] Unit = {"Ml(s)", "Teaspoon(s)", "Tablespoon(s)", "Cups(s)","Litre(s)", "Gram(s)", "Kilogram(s)", "Other"};

        public string SelectedUnit { get; set; } = string.Empty;

        public double SelectedVolume { get; set; } = 0;

        public double TotalVolume { get; set; } = 0;

        public double[] VolumePerUnit = {1, 5, 15, 237, 1000, 1, 1000, 1};

        public string MeasurementUnitHere { get; set; } = string.Empty;

        public double IngredientQuantityHere { get; set; } = 0;

        //-----------------------------------------------------------------------------------------------//
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ConversionClass() { }

        public void CheckForUpdates(double quantity, double factor)
        {
            double totalVolume = 0;
            totalVolume = quantity * factor;

            if (!SelectedUnit.Equals(Unit[5]) && !SelectedUnit.Equals(Unit[6]) && !SelectedUnit.Equals(Unit[7]))
            {
                if (totalVolume > VolumePerUnit[1] && totalVolume < VolumePerUnit[2])
                {
                    SelectedUnit = Unit[1];
                    SelectedVolume = VolumePerUnit[1];
                }
                else if (totalVolume > VolumePerUnit[2] && totalVolume < VolumePerUnit[3])
                {
                    SelectedUnit = Unit[2];
                    SelectedVolume = VolumePerUnit[2];
                }
                else if (totalVolume > VolumePerUnit[3] && totalVolume < VolumePerUnit[4])
                {
                    SelectedUnit = Unit[3];
                    SelectedVolume = VolumePerUnit[3];
                }
                else if (totalVolume > VolumePerUnit[4])
                {
                    SelectedUnit = Unit[4];
                    SelectedVolume = VolumePerUnit[4];
                }
                else
                {
                    SelectedUnit = Unit[0];
                    SelectedVolume = VolumePerUnit[0];
                }
            }
            else 
            { 
                if (totalVolume < 1000)
                {
                    SelectedUnit = Unit[5];
                    SelectedVolume = VolumePerUnit[5];
                }
                else
                {
                    SelectedUnit = Unit[6];
                    SelectedVolume = VolumePerUnit[6];

                }
            }

        }


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
        public void ConvertMillilitresToLitres(double input)
        {
            double output = 0;

            if (input >= 1000)
            {
                output = input / 1000;
                if (output == 1)
                {
                    this.MeasurementUnitHere = "Litre";
                    this.IngredientQuantityHere = output;
                }
                else
                {
                    this.MeasurementUnitHere = "Litres";
                    this.IngredientQuantityHere = output;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------//
        public void ConvertGramsToKilograms(double input)
        {
            double output = 0;

            if (input >= 1000)
            {
                output = input / 1000;
                if (output == 1)
                {
                    this.MeasurementUnitHere = "Kilogram";
                    this.IngredientQuantityHere = output;
                }
                else
                {
                    this.MeasurementUnitHere = "Kilograms";
                    this.IngredientQuantityHere = output;
                }
            }
        }

        //-----------------------------------------------------------------------------------------------//
        //-----------------------------------------------------------------------------------------------//
        public void ConvertLitresToMillilitres(double input)
        {
            double output = 0;

            if (input < 1)
            {
                output = input * 1000;
                if (output == 1)
                {
                    this.MeasurementUnitHere = "Milliitre";
                    this.IngredientQuantityHere = output;
                }
                else
                {
                    this.MeasurementUnitHere = "Millilitres";
                    this.IngredientQuantityHere = output;
                }
            }
        }


        //-----------------------------------------------------------------------------------------------//
        public void ConvertKilogramsToGrams(double input)
        {
            double output = 0;

            if (input < 1)
            {
                output = input * 1000;
                if (output == 1)
                {
                    this.MeasurementUnitHere = "Gram";
                    this.IngredientQuantityHere = output;
                }
                else
                {
                    this.MeasurementUnitHere = "Grams";
                    this.IngredientQuantityHere = output;
                }
            }
        }*/
    }
}
//------------------------------------------oo00 End of File 00oo-------------------------------------------//