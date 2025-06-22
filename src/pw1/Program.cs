using System;

namespace Station
{
    public class Program
    {
        public static void Main()
        {
            Station station = new Station();
            int option = 0;

            while (option != 4) {
                Console.Clear();
                Console.WriteLine("-----------------UFV Station-----------------------");
                Console.WriteLine("Please select one of the following options: ");
                Console.WriteLine(" 1- Load train from file");
                Console.WriteLine(" 2- Start simulation");
                Console.WriteLine(" 3- Display state");
                Console.WriteLine(" 4- Exit");
                Console.WriteLine("---------------------------------------------------");
                option = Int32.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Introduce the number of stations you want");
                        int tmp = Int32.Parse(Console.ReadLine());
                        LoadTrainsFromFile("trains.csv", station, tmp);

                        Console.WriteLine($"Loaded {station.GetTrains().Count} trains:");
                        foreach (var train in station.GetTrains())
                        {
                            Console.WriteLine($"  {train.GetId()} - Status: {train.GetStatus()}, ArrivalTime: {train.GetArrivalTime()}");
                        }
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        break;
                    case 2:
                        Console.WriteLine("Starting simulation...");
                        while (!station.AllTrainsDocked())
                        {
                            station.AdvanceTick();
                            station.DisplayStatus();
                            Console.WriteLine("Press enter to advance the next tick");
                            Console.ReadLine();
                        }
                        Console.WriteLine("Simulation finished, all trains are now docked at the station");
                        break;
                    case 3:
                        station.DisplayStatus();
                        Console.WriteLine("Press enter to go back to the menu");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid option, please introduce a correct one");
                        break;
                }
            }
        }
        static void LoadTrainsFromFile(string fileName, Station station, int platforms)
        {
            for (int i = 0; i < platforms; i++)
            {
                station.AddPlatform(new Platform("Plat" + i));
            }
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string header = sr.ReadLine();

                    string lines;
                    while ((lines = sr.ReadLine()) != null)
                    {
                        string[] parts = lines.Split(",");
                        string id = parts[0];
                        int arrivalTime = Int32.Parse(parts[1]);
                        string type = parts[2];
                        if (type == "passenger")
                        {
                            int numberOfCarriages = Int32.Parse(parts[3]);
                            int capacity = Int32.Parse(parts[4]);
                            PassengerTrain passengerTrain = new PassengerTrain(id, TrainStatus.EnRoute, arrivalTime, type, numberOfCarriages, capacity);
                            station.AddTrain(passengerTrain);
                        }
                        else if (type == "freight")
                        {
                            int maxWeight = Int32.Parse(parts[3]);
                            string freightType = parts[4];
                            FreightTrain freightTrain = new FreightTrain(id, TrainStatus.EnRoute, arrivalTime, type, maxWeight, freightType);
                            station.AddTrain(freightTrain);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The file was not found.");   
            }
        }
    }
}
