using System;

namespace Practice2
{
    public class PoliceStation : IMessageWritter
    {
        private List<string> policeCars;  // List of police cars' plates

        // Constructor
        public PoliceStation()
        {
            policeCars = new List<string>();
        }

        // Method to register a police car by its plate number
        public void RegisterPoliceCar(string plate)
        {
            if (!policeCars.Contains(plate))
            {
                policeCars.Add(plate);
                Console.WriteLine(WriteMessage($"{plate}: registered."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"{plate}: is already registered."));
            }
        }

        // Method to launch an alarm when a speeding vehicle is detected
        public void LaunchAlarm(string plate)
        {
            if (policeCars.Count == 0)
            {
                Console.WriteLine("No police cars available to respond to the alarm.");
                return;
            }

            WriteMessage($"Speeding vehicle with plate '{plate}' detected. Notifying all patrolling police cars.");
            foreach (var policeCar in policeCars)
            {
                Console.WriteLine(WriteMessage($"{policeCar}: pursuing vehicle with plate {plate}."));
            }
        }

        // Implement the IMessageWritter interface
        public string WriteMessage(string customMessage)
        {
            return $"Police car with plate {customMessage}";
        }
    }

}
