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
                Console.WriteLine(WriteMessage($"{license}: has been successfully added."));
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
                Console.WriteLine(WriteMessage($"{license}: has been successfully removed."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"{license}: does not exist."));
            }
        }

        // Method to get the police station of the city
        public PoliceStation GetPoliceStation()
        {
            return policeStation;
        }

        // Implement the IMessageWritter interface
        public string WriteMessage(string customMessage)
        {
            return $"Taxi license {customMessage}";
        }
    }

}
