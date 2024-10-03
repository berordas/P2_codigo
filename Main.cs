namespace Practice2
{
    internal class Program
    {

        static void Main()
        {
            City city = new City();
            Console.WriteLine("City created");

            PoliceStation policeStation = new PoliceStation();
            Console.WriteLine("Police station created");

            Taxi taxi1 = new Taxi("0001 AAA");
            Taxi taxi2 = new Taxi("0002 BBB");

            PoliceCar policeCar1 = new PoliceCar("0001 CNP", policeStation, true, city);
            PoliceCar policeCar2 = new PoliceCar("0002 CNP", policeStation, true, city);
            PoliceCar policeCar3 = new PoliceCar("0003 CNP", policeStation, false, city);

            Console.WriteLine(taxi1.WriteMessage("Created"));
            Console.WriteLine(taxi2.WriteMessage("Created"));
            Console.WriteLine(policeCar1.WriteMessage("Created"));
            Console.WriteLine(policeCar2.WriteMessage("Created"));

            city.AddLicense(taxi1.GetPlate());
            city.AddLicense(taxi2.GetPlate());
            city.AddLicense(taxi1.GetPlate());

            policeStation.RegisterPoliceCar(policeCar1.GetPlate());
            policeStation.RegisterPoliceCar(policeCar2.GetPlate());
            policeStation.RegisterPoliceCar(policeCar3.GetPlate());
            policeStation.RegisterPoliceCar(policeCar1.GetPlate());

            policeCar3.StartPatrolling();
            policeCar3.UseRadar(taxi1, false);

            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1, false);

            taxi2.StartRide();
            policeCar2.UseRadar(taxi2, false);
            policeCar2.StartPatrolling();
            policeCar2.UseRadar(taxi2, false);
            taxi2.StopRide();
            policeCar2.EndPatrolling();

            taxi1.StartRide();
            taxi1.StartRide();
            policeCar1.StartPatrolling();
            policeCar1.UseRadar(taxi1, true);
            taxi1.StopRide();
            taxi1.StopRide();
            policeCar1.EndPatrolling();

            policeCar1.PrintRadarHistory();
            policeCar2.PrintRadarHistory();

        }
    }
}
    

