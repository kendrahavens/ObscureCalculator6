using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ObscureCalculator6.Models
{
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