using System;

namespace Practice2
{
    public class City : IMessageWritter
    {
        private List<string> taxiLicenses;  // List of taxi licenses
        private PoliceStation policeStation;

        // Constructor
        public City()
        {
            taxiLicenses = new List<string>();
            policeStation = new PoliceStation();
        }

        // Method to add a new taxi license
        public void AddLicense(string license)
        {
            if (!taxiLicenses.Contains(license))
            {
                taxiLicenses.Add(license);
                Console.WriteLine(WriteMessage($"{license}: registered."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"{license}: is already registered."));
            }
        }

        // Method to remove an existing taxi license
        public void DropLicense(string license)
        {
            if (taxiLicenses.Contains(license))
            {
                taxiLicenses.Remove(license);
                Console.WriteLine(WriteMessage($"{license}: removed."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"{license}: does not exist."));
            }
        }

        // Implement the IMessageWritter interface
        public string WriteMessage(string customMessage)
        {
            return $"Taxi license {customMessage}";
        }
    }

}
