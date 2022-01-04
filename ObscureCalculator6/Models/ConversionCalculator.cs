using System;

namespace ObscureCalculator6.Models
{
    public class ConversionCalculator
    {
        public int Fortnight;
        public double Furlong;
        public int StonesThrow;

        public ConversionCalculator()
        {
            Fortnight = 14;
            Furlong = 8;
            StonesThrow = 51;
        }

        public int CalculateFortnight(int days)
        {
            return days / Fortnight;
        }

        public double CalculateFurlong(double miles)
        {
            return miles * Furlong;
        }

        public int CalculateStonesThrow(int feet)
        {
            return feet / StonesThrow;
        }

        // I only trust him as far as I can throw him: Trust Calculate Method
        // Based on projected person weight, thrower weight, wind resistance 
        // and the throwee's consent to be thrown.
        public double CalculateTrust(int projectilePersonWeight, int perpetratorWeight,
            double windResistance, bool consentToBeThrown, Technique technique)
        {
            #region
            //if (technique == null)
            //{
            //    throw new ArgumentNullException(nameof(technique));
            //}
            //else if (projectilePersonWeight <= 0)
            //{
            //    throw new ArgumentException("Avoid divide by zero", "projectilePersonWeight");
            //}
            #endregion
            double trustInFeet = 0;

            if (perpetratorWeight > projectilePersonWeight)
            {
                trustInFeet = (perpetratorWeight / projectilePersonWeight) * 8;
                if (consentToBeThrown)
                {
                    trustInFeet = trustInFeet + 2;
                }
                else
                {
                    trustInFeet = trustInFeet - 2;
                }
            }
            else
            {
                trustInFeet = (perpetratorWeight / projectilePersonWeight) * 5;
                if (consentToBeThrown)
                {
                    trustInFeet += 2;
                }
                else
                {
                    trustInFeet -= 3;
                }
            }

            //Subtract wind resistance
            trustInFeet = trustInFeet - windResistance;

            trustInFeet = technique.ThrowTechnique == "curling" ? trustInFeet + technique.Success : trustInFeet;

            return trustInFeet;
        }

        public class Technique
        {
            // Throwing technique
            string throwTechnique;
            // Success in applying technique on a scale of 1-5
            int success;

            public Technique()
            {
                throwTechnique = "curling";
                Success = 2;
            }

            public string ThrowTechnique { get => throwTechnique; set => throwTechnique = value; }
            public int Success { get => success; set => success = value; }
        }

    }
}
