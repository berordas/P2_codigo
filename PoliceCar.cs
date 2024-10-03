namespace Practice2
{
    class PoliceCar : Vehicle
    {
        //constant string as TypeOfVehicle wont change allong PoliceCar instances
        private const string typeOfVehicle = "Police Car"; 
        private bool isPatrolling;
        private SpeedRadar? speedRadar;
        public PoliceStation policeStation;
        public City city;

        public PoliceCar(string plate, PoliceStation policeStation, bool radar, City city) : base(typeOfVehicle, plate)
        {
            isPatrolling = false;
            if (radar)
            {
                speedRadar = new SpeedRadar();  // Assigning a SpeedRadar 
            }
            else
            {
                speedRadar = null;
            }
            this.policeStation = policeStation;
            this.city = city;
        }

        public void UseRadar(Vehicle vehicle, bool catched)
        {
            if (isPatrolling && speedRadar != null)
            {
                string ilegal_plate = speedRadar.TriggerRadar(vehicle);
                if (ilegal_plate != null)
                {
                    policeStation.LaunchAlarm(ilegal_plate);
                    if (catched)
                    {
                        CatchedVehicle(ilegal_plate);
                    }
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

        public void CatchedVehicle(string plate)
        {
            city.DropLicense(plate);
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
            if (speedRadar != null)
            {
                Console.WriteLine(WriteMessage("Report radar speed history:"));
                foreach (float speed in speedRadar.SpeedHistory)
                {
                    Console.WriteLine(speed);
                }
            }
            else
            {
                Console.WriteLine(WriteMessage("has no radar."));
            }
        }
    }
}