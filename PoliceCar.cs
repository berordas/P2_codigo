namespace Practice2
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar? speedRadar;
        public PoliceStation policeStation;

        public PoliceCar(string plate, PoliceStation policeStation) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            speedRadar = new SpeedRadar();
            this.policeStation = policeStation;
        }

        private void LaunchAlarm(string vehiclePlate)
        {
            WriteMessage("Launching alarm for vehicle with plate: " + vehiclePlate);
            policeStation.LaunchAlarm(vehiclePlate);
        }

        public void UseRadar(Vehicle vehicle)
        {
            if (isPatrolling && speedRadar != null)
            {
                string ilegal_plate = speedRadar.TriggerRadar(vehicle);
                if (ilegal_plate != null)
                {
                    LaunchAlarm(ilegal_plate);
                }

                string meassurement = speedRadar.GetLastReading();
                Console.WriteLine(WriteMessage($"Triggered radar. Result: {meassurement}"));
            }
            else if (speedRadar != null)
            {
                Console.WriteLine(WriteMessage($"has no active radar."));
            }
            else
            {
                Console.WriteLine(WriteMessage($"has no radar."));
            }
        }

        public bool IsPatrolling()
        {
            return isPatrolling;
        }

        public void StartPatrolling()
        {
            if (!isPatrolling)
            {
                isPatrolling = true;
                Console.WriteLine(WriteMessage("started patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("is already patrolling."));
            }
        }

        public void EndPatrolling()
        {
            if (isPatrolling)
            {
                isPatrolling = false;
                Console.WriteLine(WriteMessage("stopped patrolling."));
            }
            else
            {
                Console.WriteLine(WriteMessage("was not patrolling."));
            }
        }

        public void PrintRadarHistory()
        {
            Console.WriteLine(WriteMessage("Report radar speed history:"));
            foreach (float speed in speedRadar.SpeedHistory)
            {
                Console.WriteLine(speed);
            }
        }
    }
}