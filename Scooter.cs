using System;
using System.Drawing;
using System.Reflection;

namespace Practice2
{
    class Scooter : Vehicle
    {
        private static string typeOfVehicle = "Scooter";

        // Constructor
        public Scooter(string plate) : base(typeOfVehicle, plate)
        {
            
        }
    }
}
